PRINT 'Starting job Transaction Backup...'; 
PRINT @@SERVERNAME
DECLARE @Directory VARCHAR(128)='\\vamwin\shares\SQLBackups\SQL Server Backups - Daily'
EXEC [Admin].[dbo].[DatabaseBackup]  
	@Databases='USER_DATABASES'  
	,@Directory=@Directory
	,@BackupType='LOG' 
	,@Verify='Y' 
	,@CleanupTime=48 
	,@CleanupMode='AFTER_BACKUP' 
	,@Compress='Y' 
	,@CheckSum='Y' 
	,@Description='Standard transaction logs Backup'
