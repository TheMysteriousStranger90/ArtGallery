$path = "D:\MyProjects\ArtGallery\src\UI\ArtGallery.ClientApp\Pages\Gallery.razor.tmp"
[string]$c = Get-Content $path -Raw

# Replace _currentSort backing field + CurrentSort property with auto-property
$old1 = @"
    private string _currentSort = "title";

    [Parameter]
    [SupplyParameterFromQuery]
    public string CurrentSort
"@
$new1 = @"
    [Parameter]
    [SupplyParameterFromQuery]
    public string CurrentSort { get; set; } = "title";

    [Parameter]
    [SupplyParameterFromQuery]
    public string IgnorePlaceholder
"@
if ($c.Contains($old1)) { Write-Host "Found CurrentSort block" } else { Write-Host "CurrentSort block NOT found" }
