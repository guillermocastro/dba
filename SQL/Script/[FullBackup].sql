    PRINT 'Starting job Full Backup...'; 
    PRINT @@SERVERNAME
	/* 
	Normal Backup for Non-SQL Server Express SQL Servers
	Notice, SQL Server Express does not allow Compressed backup
	*/
	PRINT @@SERVERNAME
	DECLARE @Folder VARCHAR(128)=REPLACE(@@SERVERNAME,'\','$')
	DECLARE @Date DATE=CONVERT(DATE,GETDATE())
	--Normal Backup
	PRINT 'Daily Backup'
	DECLARE @Directory VARCHAR(128)='\\vamwin\shares\SQLBackups\SQL Server Backups - Daily'
	DECLARE @Cmd NVARCHAR(MAX)


	IF DATEPART(dw,GETDATE())=6 --It's  Friday
	BEGIN
		PRINT 'Weekly backup'
		SET @Directory='\\vamwin\shares\SQLBackups\SQL Server Backups - Weekly'
		--\\Sk-sqlgendb-01\tsql\Powershell\Live\CopyBackup.ps1 -source "\\vamwin\shares\SQLBackups\\SQL Server Backups - Daily" -destination "\\vamwin\shares\SQLBackups\\SQL Server Backups - Annual - 4 year" -folder "SK-SQLGENDB-01" -days 1
		EXEC [Admin].[dbo].[DatabaseBackup] @Databases='ALL_DATABASES' ,@Directory=@Directory,@BackupType='FULL' ,@Verify='Y' ,@CleanupTime=120 ,@CleanupMode='AFTER_BACKUP' ,@Compress='Y' ,@CheckSum='Y' ,@Description='Weekly Backup'
	END
	ELSE
	BEGIN
		EXEC [Admin].[dbo].[DatabaseBackup] @Databases='ALL_DATABASES' ,@Directory=@Directory,@BackupType='FULL' ,@Verify='Y' ,@CleanupTime=120 ,@CleanupMode='AFTER_BACKUP' ,@Compress='Y' ,@CheckSum='Y' ,@Description='Daily Backup'
	END

	IF @Date=CONVERT(DATE,convert(datetime,convert(date,dateadd(dd,-(day(dateadd(mm,1,getdate()))),dateadd(mm,1,getdate())),100),100))
	BEGIN
		SET @Directory='\\vamwin\shares\SQLBackups\SQL Server Backups - Monthly'
		PRINT 'Monhly backup'
		EXEC [Admin].[dbo].[DatabaseBackup] @Databases='ALL_DATABASES' ,@Directory=@Directory,@BackupType='FULL' ,@Verify='Y' ,@CleanupTime=120 ,@CleanupMode='AFTER_BACKUP' ,@Compress='Y' ,@CheckSum='Y' ,@Description='Monthly Backup'
	END

	IF DATEPART(DAY,GETDATE())=31 AND DATEPART(MONTH,GETDATE())=4
	BEGIN
		PRINT 'End of year!!!!'
		IF @@SERVERNAME IN ('SK-SECDB-01\SATEONDB','SK-NAV-03','SK-NAVDB-02','SK-CASCADEDB-01','SK-SECDB-01\TRAKADB','SK-SECDB-01\TRAKADB','SK-CRMSDB-01')
		BEGIN
			PRINT 'Critical data!!!!'
			SET @Directory='\\vamwin\shares\SQLBackups\SQL Server Backups - Annual - 7 year'		
			EXEC [Admin].[dbo].[DatabaseBackup] @Databases='ALL_DATABASES' ,@Directory=@Directory,@BackupType='FULL' ,@Verify='Y' ,@CleanupTime=120 ,@CleanupMode='AFTER_BACKUP' ,@Compress='Y' ,@CheckSum='Y' ,@Description='Yearly Backup 7 years'
		END
		ELSE
		BEGIN
			PRINT 'Normal data!!!!'
			SET @Directory='\\vamwin\shares\SQLBackups\SQL Server Backups - Annual - 4 year'
			EXEC [Admin].[dbo].[DatabaseBackup] @Databases='ALL_DATABASES' ,@Directory=@Directory,@BackupType='FULL' ,@Verify='Y' ,@CleanupTime=120 ,@CleanupMode='AFTER_BACKUP' ,@Compress='Y' ,@CheckSum='Y' ,@Description='Yearly Backup 7 years'
		END
	END
