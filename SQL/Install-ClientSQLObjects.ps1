param ([String]$instance)
Set-Location C:\PowerShell\dbm
Import-Module .\dbm.psm1 -Force
if ($instance)
{
#Write-Host "Create the Admin Database if not exists " -ForegroundColor Magenta
$clientdb="Admin"
$sqlquery="IF NOT (EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Admin')) CREATE DATABASE Admin;"
$h=Get-Host -instance $instance
$cc=Get-CS -svr $h -database "master"
Invoke-Transaction -cs $cc -sqlquery $sqlquery

#Write-Host "Install/Update the Client Scripts "$h[1] -ForegroundColor Magenta
$sqlquery=""
$cc=Get-CS -svr $h -database $clientdb
#sqlcmd -S $h -i .\Client.sql
sqlcmd -S $h -i .\Client.sql
}