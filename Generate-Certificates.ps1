# Enhanced-Generate-Certificates.ps1
param(
    [string[]]$Domains = @("localhost", "127.0.0.1", "::1"),
    [int]$ValidityDays = 365
)

# Create certificates directory if it doesn't exist
$certificatesPath = Join-Path $PSScriptRoot "certificates"
if (-not (Test-Path $certificatesPath)) {
    New-Item -ItemType Directory -Path $certificatesPath | Out-Null
    Write-Host "Created certificates directory at $certificatesPath" -ForegroundColor Green
}

# Check if OpenSSL is installed
try {
    $openSSLVersion = openssl version
    Write-Host "Using $openSSLVersion" -ForegroundColor Cyan
} catch {
    Write-Host "OpenSSL is not installed or not in PATH. Please install OpenSSL and try again." -ForegroundColor Red
    Write-Host "You can download it from https://slproweb.com/products/Win32OpenSSL.html" -ForegroundColor Yellow
    exit 1
}

# Create OpenSSL config file with SAN (Subject Alternative Names)
$configContent = @"
[req]
distinguished_name = req_distinguished_name
req_extensions = v3_req
prompt = no

[req_distinguished_name]
C=US
ST=Development
L=Development
O=Development Organization
OU=Development Unit
CN=localhost

[v3_req]
basicConstraints = CA:FALSE
keyUsage = nonRepudiation, digitalSignature, keyEncipherment
extendedKeyUsage = serverAuth, clientAuth
subjectAltName = @alt_names

[alt_names]
"@

# Add domains to SAN
$dnsCount = 1
$ipCount = 1

foreach ($domain in $Domains) {
    if ($domain -match "^\d+\.\d+\.\d+\.\d+$" -or $domain -match "::") {
        $configContent += "IP.$ipCount = $domain`n"
        $ipCount++
    } else {
        $configContent += "DNS.$dnsCount = $domain`n"
        $dnsCount++
    }
}

$configPath = Join-Path $certificatesPath "openssl.conf"
$configContent | Out-File -FilePath $configPath -Encoding UTF8

# Set paths for certificate files
$privateKeyPath = Join-Path $certificatesPath "privkey.pem"
$certPath = Join-Path $certificatesPath "cert.pem"
$fullchainPath = Join-Path $certificatesPath "fullchain.pem"

Write-Host "Generating private key..." -ForegroundColor Yellow
openssl genrsa -out $privateKeyPath 2048

if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to generate private key" -ForegroundColor Red
    exit 1
}

Write-Host "Generating certificate with SAN extensions..." -ForegroundColor Yellow
openssl req -new -x509 -key $privateKeyPath -out $certPath -days $ValidityDays -config $configPath -extensions v3_req

if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to generate certificate" -ForegroundColor Red
    exit 1
}

# For self-signed certs, cert.pem and fullchain.pem are the same
Copy-Item $certPath $fullchainPath

# Set appropriate permissions (Windows)
Write-Host "Setting file permissions..." -ForegroundColor Yellow
try {
    icacls $privateKeyPath /inheritance:r /grant:r "$($env:USERNAME):(R,W)" /c
    icacls $certPath /inheritance:r /grant:r "$($env:USERNAME):(R)" /c
    icacls $fullchainPath /inheritance:r /grant:r "$($env:USERNAME):(R)" /c
} catch {
    Write-Host "Warning: Could not set file permissions. This may not be critical." -ForegroundColor Yellow
}

# Clean up config file
Remove-Item $configPath -Force

Write-Host "`nCertificate files generated successfully:" -ForegroundColor Green
Write-Host "Private Key: $privateKeyPath"
Write-Host "Certificate: $certPath"
Write-Host "Full Chain: $fullchainPath"
Write-Host "Valid for $ValidityDays days"

Write-Host "`nCertificate includes the following domains/IPs:" -ForegroundColor Green
foreach ($domain in $Domains) {
    Write-Host "  - $domain"
}

# Verify certificate
Write-Host "`nVerifying generated certificate..." -ForegroundColor Cyan
try {
    $certInfo = openssl x509 -in $certPath -text -noout
    Write-Host "Certificate verification completed successfully" -ForegroundColor Green
} catch {
    Write-Host "Warning: Could not verify certificate" -ForegroundColor Yellow
}

Write-Host "`nIMPORTANT NOTES:" -ForegroundColor Yellow
Write-Host "1. These are self-signed certificates for development purposes only."
Write-Host "2. Do not use these certificates in production environments."
Write-Host "3. Run Import-Certificate.ps1 to add the certificate to trusted store."
Write-Host "4. You may need to restart your browser after importing the certificate."