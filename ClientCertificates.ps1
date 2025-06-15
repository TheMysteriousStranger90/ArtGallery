$certificatesPath = Join-Path $PSScriptRoot "certificates"
if (-not (Test-Path $certificatesPath)) {
    New-Item -ItemType Directory -Path $certificatesPath | Out-Null
    Write-Host "Created certificates directory at $certificatesPath"
}

try {
    $openSSLVersion = openssl version
    Write-Host "Using $openSSLVersion"
} catch {
    Write-Host "OpenSSL is not installed or not in PATH. Please install OpenSSL and try again." -ForegroundColor Red
    Write-Host "You can download it from https://slproweb.com/products/Win32OpenSSL.html" -ForegroundColor Yellow
    exit 1
}

$clientPrivateKeyPath = Join-Path $certificatesPath "client-privkey.pem"
$clientCertPath = Join-Path $certificatesPath "client-cert.pem"
$clientFullchainPath = Join-Path $certificatesPath "client-fullchain.pem"
$clientPfxPath = Join-Path $certificatesPath "client.pfx"

Write-Host "Generating client private key..."
openssl genrsa -out $clientPrivateKeyPath 2048

Write-Host "Generating self-signed client certificate..."
$subjectName = "/C=US/ST=State/L=City/O=Organization/CN=artgallery-client"

openssl req -new -x509 -key $clientPrivateKeyPath -out $clientCertPath -days 365 -subj $subjectName

Copy-Item $clientCertPath $clientFullchainPath

# Create PFX/PKCS12 file for .NET applications
$password = "YourStrong!Password"
Write-Host "Creating PFX file with password: $password"
openssl pkcs12 -export -out $clientPfxPath -inkey $clientPrivateKeyPath -in $clientCertPath -password pass:$password

# Set appropriate permissions
Write-Host "Setting file permissions..."
# On Windows, we don't need the same chmod commands as Linux, but we'll restrict access
icacls $clientPrivateKeyPath /inheritance:r
icacls $clientPrivateKeyPath /grant:r "$($env:USERNAME):(R,W)"
icacls $clientPfxPath /inheritance:r
icacls $clientPfxPath /grant:r "$($env:USERNAME):(R,W)"

Write-Host "Client certificate files generated successfully:" -ForegroundColor Green
Write-Host "Private Key: $clientPrivateKeyPath"
Write-Host "Certificate: $clientCertPath"
Write-Host "Full Chain: $clientFullchainPath"
Write-Host "PFX File: $clientPfxPath"

Write-Host "`nIMPORTANT: These are self-signed certificates for development purposes only." -ForegroundColor Yellow
Write-Host "Do not use these certificates in production environments." -ForegroundColor Yellow