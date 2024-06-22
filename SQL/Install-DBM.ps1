# Install-DBM
# This Scripts creates the cbm.ps1xml file with the configuration of the Central Server.
    Function Get-Folder($initialDirectory,$description)

    {
        $p=Get-location
        [System.Reflection.Assembly]::LoadWithPartialName("System.windows.forms")|Out-Null
        Set-Location -Path $initialDirectory
        $foldername = New-Object System.Windows.Forms.FolderBrowserDialog
        $foldername.Description = $description
        #$foldername.GetType('System.Environment+SpecialFolder')
        #$foldername.rootfolder = "MyComputer"
        #$foldername.RootFolder=Environment.SpecialFolder.MyComputer
        $foldername.SelectedPath=$initialDirectory
        #[Enum]::GetNames([System.Environment+SpecialFolder])

    
        if($foldername.ShowDialog() -eq "OK")
        {
            $folder += $foldername.SelectedPath
        }
        Set-Location -Path $p
        return $folder
    }

    [string]$defaultlocation="\\vamwin\shares\sqlbackups"
    [string]$location=Get-Location
    [string]$filename=$location+"\"+"dbm.ps1xml"
    $xml = New-Object xml

    # Create Declaration
    $xmlDeclaration=$xml.CreateXmlDeclaration("1.0", "UTF-16", $null)
    $xml.AppendChild($xmlDeclaration)
    # Create Root element
    $configElement=$xml.CreateElement("config")

    $configElement.SetAttribute("Program","dbm")
    $configElement.SetAttribute("Version","1.0.0")
    $configElement.SetAttribute("Author","Guillermo Castro")
    $configElement.SetAttribute("Date",$(get-date -f yyyy-MM-dd))
    $configElement.SetAttribute("KeepLogDays",90)
    $configElement.SetAttribute("KeepFullBackups",4)
    $configElement.SetAttribute("KeepLogBackups",2)

    [string]$instance=Read-Host "Enter the Central Server Instance"
    [string]$dwserver=Read-Host "Enter the Central Server host"
    [string]$dwdb=Read-Host "Enter the Central Server Database"
    [string]$dwusr=Read-Host "Enter the Username (If exists)"
    if ($dwusr -ne "")
    {
        $dwpwd=Read-Host "Enter the password"
        $dwpwd = ConvertTo-SecureString $dwpwd -AsPlainText -Force
    }
    else
    {
        $dwpwd=""
    }
    [string]$dbm=Get-Folder -initialDirectory "C:\PowerShell\dbm" -description "Enter the dbm script folder"
    [string]$tempfiles=Get-Folder -initialDirectory $defaultlocation -description "Enter the temporary files folder"
    [string]$daily=Get-Folder -initialDirectory $defaultlocation -description "Enter the daily backup folder"
    [string]$weekly=Get-Folder -initialDirectory $defaultlocation -description "Enter the weekly backup folder"
    [string]$monthly=Get-Folder -initialDirectory $defaultlocation -description "Enter the monthly backup folder"
    [string]$yearly4=Get-Folder -initialDirectory $defaultlocation -description "Enter the yearly backup folder (4 years retention)"
    [string]$yearly7=Get-Folder -initialDirectory $defaultlocation -description "Enter the yearly backup folder (7 years retention)"


    $centralElement=$xml.CreateElement("central")
    $centralElement.SetAttribute("instance",$instance)
    $centralElement.SetAttribute("host",$dwserver)
    $centralElement.SetAttribute("catalog",$dwdb)
    $centralElement.SetAttribute("username",$dwusr)
    $centralElement.SetAttribute("password",$dwpwd)
    $centralElement.SetAttribute("tempfiles",$tempfiles)
    $centralElement.SetAttribute("daily",$daily)
    $centralElement.SetAttribute("weekly",$weekly)
    $centralElement.SetAttribute("monthly",$monthly)
    $centralElement.SetAttribute("yearly4",$yearly4)
    $centralElement.SetAttribute("yearly7",$yearly7)
    $centralElement.SetAttribute("dbm",$dbm)
    $xml.AppendChild($configElement)

    $configElement.AppendChild($centralElement)

    [string]$filename=$dbm+"\"+"dbm.ps1xml"
    Set-Location -Path $dbm
    $xml.Save($filename)


