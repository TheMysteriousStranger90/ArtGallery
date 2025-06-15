# Import-Certificate.ps1
param(
    [switch]$CurrentUser,
    [switch]$LocalMachine,
    [switch]$Force
)

# Default to CurrentUser if no parameter specified
if (-not $CurrentUser -and -not $LocalMachine) {
    $CurrentUser = $true
}

$certificatesPath = Join-Path $PSScriptRoot "certificates"
$certPath = Join-Path $certificatesPath "cert.pem"

Write-Host "Certificate Import Script" -ForegroundColor Cyan
Write-Host "=========================" -ForegroundColor Cyan

# Check if certificate file exists
if (-not (Test-Path $certPath)) {
    Write-Host "Certificate file not found at $certPath" -ForegroundColor Red
    Write-Host "Please run Enhanced-Generate-Certificates.ps1 first." -ForegroundColor Yellow
    exit 1
}

# Function to import certificate
function Import-CertificateToStore {
    param(
        [string]$CertPath,
        [System.Security.Cryptography.X509Certificates.StoreLocation]$StoreLocation,
        [switch]$Force
    )

    try {
        Write-Host "Loading certificate from $CertPath..." -ForegroundColor Yellow

        # Load the certificate
        $cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($CertPath)

        Write-Host "Certificate Details:" -ForegroundColor Cyan
        Write-Host "  Subject: $($cert.Subject)"
        Write-Host "  Issuer: $($cert.Issuer)"
        Write-Host "  Valid From: $($cert.NotBefore)"
        Write-Host "  Valid To: $($cert.NotAfter)"
        Write-Host "  Thumbprint: $($cert.Thumbprint)"

        # Open the certificate store
        $storeName = [System.Security.Cryptography.X509Certificates.StoreName]::Root
        $store = New-Object System.Security.Cryptography.X509Certificates.X509Store($storeName, $StoreLocation)

        Write-Host "Opening certificate store: $storeName at $StoreLocation..." -ForegroundColor Yellow
        $store.Open([System.Security.Cryptography.X509Certificates.OpenFlags]::ReadWrite)

        # Check if certificate already exists
        $existingCerts = $store.Certificates | Where-Object { $_.Thumbprint -eq $cert.Thumbprint }

        if ($existingCerts -and -not $Force) {
            Write-Host "Certificate already exists in the store." -ForegroundColor Yellow
            Write-Host "Use -Force parameter to overwrite." -ForegroundColor Yellow
            $store.Close()
            return $false
        }

        if ($existingCerts -and $Force) {
            Write-Host "Removing existing certificate..." -ForegroundColor Yellow
            foreach ($existingCert in $existingCerts) {
                $store.Remove($existingCert)
            }
        }

        # Add the certificate to the store
        Write-Host "Adding certificate to trusted root certificates..." -ForegroundColor Yellow
        $store.Add($cert)
        $store.Close()

        Write-Host "Certificate successfully added to $StoreLocation trusted root certificates store!" -ForegroundColor Green
        return $true

    } catch [System.UnauthorizedAccessException] {
        Write-Host "Access denied. You need administrator privileges to modify the LocalMachine certificate store." -ForegroundColor Red
        Write-Host "Please run PowerShell as Administrator or use -CurrentUser parameter." -ForegroundColor Yellow
        return $false
    } catch [System.Security.Cryptography.CryptographicException] {
        Write-Host "Error reading certificate file. The file may be corrupted or in wrong format." -ForegroundColor Red
        Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
        return $false
    } catch {
        Write-Host "Unexpected error occurred: $($_.Exception.Message)" -ForegroundColor Red
        Write-Host "Stack trace: $($_.Exception.StackTrace)" -ForegroundColor Red
        return $false
    }
}

# Import to CurrentUser store
if ($CurrentUser) {
    Write-Host "`nImporting to CurrentUser certificate store..." -ForegroundColor Cyan
    $success = Import-CertificateToStore -CertPath $certPath -StoreLocation CurrentUser -Force:$Force

    if ($success) {
        Write-Host "✅ Certificate imported to CurrentUser store successfully!" -ForegroundColor Green
    }
}

# Import to LocalMachine store (requires admin privileges)
if ($LocalMachine) {
    Write-Host "`nImporting to LocalMachine certificate store..." -ForegroundColor Cyan

    # Check if running as administrator
    $isAdmin = ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")

    if (-not $isAdmin) {
        Write-Host "Administrator privileges required for LocalMachine store." -ForegroundColor Red
        Write-Host "Please run PowerShell as Administrator." -ForegroundColor Yellow
    } else {
        $success = Import-CertificateToStore -CertPath $certPath -StoreLocation LocalMachine -Force:$Force

        if ($success) {
            Write-Host "✅ Certificate imported to LocalMachine store successfully!" -ForegroundColor Green
        }
    }
}

Write-Host "`nNext Steps:" -ForegroundColor Yellow
Write-Host "1. Restart your browser for changes to take effect"
Write-Host "2. Clear browser cache if necessary"
Write-Host "3. Navigate to https://localhost:8081 in your browser"
Write-Host "4. The security warning should no longer appear"

Write-Host "`nTroubleshooting:" -ForegroundColor Cyan
Write-Host "- If you still see warnings, try importing to LocalMachine store with admin privileges"
Write-Host "- Some browsers may still show warnings for localhost certificates"
Write-Host "- You can always click 'Advanced' -> 'Proceed to localhost (unsafe)' to continue"

Write-Host "`nTo remove the certificate later, use:" -ForegroundColor Magenta
Write-Host "certlm.msc (for LocalMachine) or certmgr.msc (for CurrentUser)"
Write-Host "Navigate to Trusted Root Certification Authorities -> Certificates"
Write-Host "Find and delete the certificate with subject 'CN=localhost'"