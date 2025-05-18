# Generate-Certificates.ps1

# Create certificates directory if it doesn't exist
$certificatesPath = Join-Path $PSScriptRoot "certificates"
if (-not (Test-Path $certificatesPath)) {
    New-Item -ItemType Directory -Path $certificatesPath | Out-Null
    Write-Host "Created certificates directory at $certificatesPath"
}

# Check if OpenSSL is installed
try {
    $openSSLVersion = openssl version
    Write-Host "Using $openSSLVersion"
} catch {
    Write-Host "OpenSSL is not installed or not in PATH. Please install OpenSSL and try again." -ForegroundColor Red
    Write-Host "You can download it from https://slproweb.com/products/Win32OpenSSL.html" -ForegroundColor Yellow
    exit 1
}

# Set paths for certificate files
$privateKeyPath = Join-Path $certificatesPath "privkey.pem"
$certPath = Join-Path $certificatesPath "cert.pem"
$fullchainPath = Join-Path $certificatesPath "fullchain.pem"

# Generate private key
Write-Host "Generating private key..."
openssl genrsa -out $privateKeyPath 2048

# Generate self-signed certificate (valid for 1 year)
Write-Host "Generating self-signed certificate..."
$subjectName = "/C=US/ST=State/L=City/O=Organization/CN=localhost"

openssl req -new -x509 -key $privateKeyPath -out $certPath -days 365 -subj $subjectName

# For self-signed certs, cert.pem and fullchain.pem are the same
Copy-Item $certPath $fullchainPath

# Set appropriate permissions
Write-Host "Setting file permissions..."
# On Windows, we don't need the same chmod commands as Linux, but we'll restrict access
icacls $privateKeyPath /inheritance:r
icacls $privateKeyPath /grant:r "$($env:USERNAME):(R,W)"

Write-Host "Certificate files generated successfully:" -ForegroundColor Green
Write-Host "Private Key: $privateKeyPath"
Write-Host "Certificate: $certPath"
Write-Host "Full Chain: $fullchainPath"

Write-Host "`nIMPORTANT: These are self-signed certificates for development purposes only." -ForegroundColor Yellow
Write-Host "Do not use these certificates in production environments." -ForegroundColor Yellow