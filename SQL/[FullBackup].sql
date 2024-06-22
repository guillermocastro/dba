USE [msdb]
GO

/****** Object:  Job [[FullBackup]]    Script Date: 22/06/2024 07:43:43 ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** Object:  JobCategory [VAMDBA]    Script Date: 22/06/2024 07:43:43 ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'VAMDBA' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'VAMDBA'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'[FullBackup]', 
		@enabled=1, 
		@notify_level_eventlog=2, 
		@notify_level_email=2, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'[FullBackup]', 
		@category_name=N'VAMDBA', 
		@owner_login_name=N'sa', 
		@notify_email_operator_name=N'SQL_DBA_O', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** Object:  Step [[FullBackup]]    Script Date: 22/06/2024 07:43:44 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'[FullBackup]', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_success_step_id=0, 
		@on_fail_action=2, 
		@on_fail_step_id=0, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'PRINT ''Starting job Full Backup...''; 
    PRINT @@SERVERNAME
	/* 
	Normal Backup for Non-SQL Server Express SQL Servers
	Notice, SQL Server Express does not allow Compressed backup
	*/
	PRINT @@SERVERNAME
	DECLARE @Folder VARCHAR(128)=REPLACE(@@SERVERNAME,''\'',''$'')
	DECLARE @Date DATE=CONVERT(DATE,GETDATE())
	--Normal Backup
	PRINT ''Daily Backup''
	DECLARE @Directory VARCHAR(128)=''\\vamwin\shares\SQLBackups\SQL Server Backups - Daily''
	DECLARE @Cmd NVARCHAR(MAX)


	IF DATEPART(dw,GETDATE())=6 --It''s  Friday
	BEGIN
		PRINT ''Weekly backup''
		SET @Directory=''\\vamwin\shares\SQLBackups\SQL Server Backups - Weekly''
		--\\Sk-sqlgendb-01\tsql\Powershell\Live\CopyBackup.ps1 -source "\\vamwin\shares\SQLBackups\\SQL Server Backups - Daily" -destination "\\vamwin\shares\SQLBackups\\SQL Server Backups - Annual - 4 year" -folder "SK-SQLGENDB-01" -days 1
		EXEC [Admin].[dbo].[DatabaseBackup] @Databases=''ALL_DATABASES'' ,@Directory=@Directory,@BackupType=''FULL'' ,@Verify=''Y'' ,@CleanupTime=120 ,@CleanupMode=''AFTER_BACKUP'' ,@Compress=''Y'' ,@CheckSum=''Y'' ,@Description=''Weekly Backup''
	END
	ELSE
	BEGIN
		EXEC [Admin].[dbo].[DatabaseBackup] @Databases=''ALL_DATABASES'' ,@Directory=@Directory,@BackupType=''FULL'' ,@Verify=''Y'' ,@CleanupTime=120 ,@CleanupMode=''AFTER_BACKUP'' ,@Compress=''Y'' ,@CheckSum=''Y'' ,@Description=''Daily Backup''
	END

	IF @Date=CONVERT(DATE,convert(datetime,convert(date,dateadd(dd,-(day(dateadd(mm,1,getdate()))),dateadd(mm,1,getdate())),100),100))
	BEGIN
		SET @Directory=''\\vamwin\shares\SQLBackups\SQL Server Backups - Monthly''
		PRINT ''Monhly backup''
		EXEC [Admin].[dbo].[DatabaseBackup] @Databases=''ALL_DATABASES'' ,@Directory=@Directory,@BackupType=''FULL'' ,@Verify=''Y'' ,@CleanupTime=120 ,@CleanupMode=''AFTER_BACKUP'' ,@Compress=''Y'' ,@CheckSum=''Y'' ,@Description=''Monthly Backup''
	END

	IF DATEPART(DAY,GETDATE())=31 AND DATEPART(MONTH,GETDATE())=4
	BEGIN
		PRINT ''End of year!!!!''
		IF @@SERVERNAME IN (''SK-SECDB-01\SATEONDB'',''SK-NAV-03'',''SK-NAVDB-02'',''SK-CASCADEDB-01'',''SK-SECDB-01\TRAKADB'',''SK-SECDB-01\TRAKADB'',''SK-CRMSDB-01'')
		BEGIN
			PRINT ''Critical data!!!!''
			SET @Directory=''\\vamwin\shares\SQLBackups\SQL Server Backups - Annual - 7 year''		
			EXEC [Admin].[dbo].[DatabaseBackup] @Databases=''ALL_DATABASES'' ,@Directory=@Directory,@BackupType=''FULL'' ,@Verify=''Y'' ,@CleanupTime=120 ,@CleanupMode=''AFTER_BACKUP'' ,@Compress=''Y'' ,@CheckSum=''Y'' ,@Description=''Yearly Backup 7 years''
		END
		ELSE
		BEGIN
			PRINT ''Normal data!!!!''
			SET @Directory=''\\vamwin\shares\SQLBackups\SQL Server Backups - Annual - 4 year''
			EXEC [Admin].[dbo].[DatabaseBackup] @Databases=''ALL_DATABASES'' ,@Directory=@Directory,@BackupType=''FULL'' ,@Verify=''Y'' ,@CleanupTime=120 ,@CleanupMode=''AFTER_BACKUP'' ,@Compress=''Y'' ,@CheckSum=''Y'' ,@Description=''Yearly Backup 7 years''
		END
	END
', 
		@database_name=N'Admin', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'[FullBackup]', 
		@enabled=1, 
		@freq_type=8, 
		@freq_interval=127, 
		@freq_subday_type=1, 
		@freq_subday_interval=0, 
		@freq_relative_interval=0, 
		@freq_recurrence_factor=1, 
		@active_start_date=20190530, 
		@active_end_date=99991231, 
		@active_start_time=190000, 
		@active_end_time=235959, 
		@schedule_uid=N'dc072e8d-0b84-4e11-adf5-4cf9aa5366ca'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:
GO


