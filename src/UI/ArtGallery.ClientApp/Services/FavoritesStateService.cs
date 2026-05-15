using ArtGallery.ClientApp.Services.Interfaces;

namespace ArtGallery.ClientApp.Services;

/// <summary>
/// Caches favorite IDs client-side so PaintingCard / ArtistCard components
/// never need to call the API individually. Gallery/Artists pages populate
/// this cache once per load; cards just read from it.
/// </summary>
public class FavoritesStateService
{
    private readonly IPaintingService _paintingService;
    private readonly IArtistService  _artistService;
    private readonly ILogger<FavoritesStateService> _logger;

    private HashSet<Guid> _favoritePaintingIds = new();
    private HashSet<Guid> _favoriteArtistIds   = new();

    private bool _paintingsLoaded;
    private bool _artistsLoaded;

    public event Action? OnChange;

    public FavoritesStateService(
        IPaintingService paintingService,
        IArtistService artistService,
        ILogger<FavoritesStateService> logger)
    {
        _paintingService = paintingService;
        _artistService   = artistService;
        _logger          = logger;
    }

    public bool IsPaintingFavorite(Guid id) => _favoritePaintingIds.Contains(id);
    public bool IsArtistFavorite(Guid id)   => _favoriteArtistIds.Contains(id);

    public async Task LoadPaintingFavoritesAsync()
    {
        if (_paintingsLoaded) { return; }
        try
        {
            var result = await _paintingService.GetFavoritePaintingsAsync();
            if (result.Success)
            {
                _favoritePaintingIds = result.FavoritePaintings
                    .Select(p => p.Id).ToHashSet();
            }
            _paintingsLoaded = true;
            OnChange?.Invoke();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load favorite paintings");
        }
    }

    public async Task LoadArtistFavoritesAsync()
    {
        if (_artistsLoaded) { return; }
        try
        {
            var result = await _artistService.GetFavoriteArtistsAsync();
            if (result.Success)
            {
                _favoriteArtistIds = result.FavoriteArtists
                    .Select(a => a.Id).ToHashSet();
            }
            _artistsLoaded = true;
            OnChange?.Invoke();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load favorite artists");
        }
    }

    public void MarkPaintingFavorite(Guid id)
    {
        _favoritePaintingIds.Add(id);
        OnChange?.Invoke();
    }

    public void MarkArtistFavorite(Guid id)
    {
        _favoriteArtistIds.Add(id);
        OnChange?.Invoke();
    }

    /// <summary>Call after logout so stale data is not shown on next login.</summary>
    public void Clear()
    {
        _favoritePaintingIds.Clear();
        _favoriteArtistIds.Clear();
        _paintingsLoaded = false;
        _artistsLoaded   = false;
        OnChange?.Invoke();
    }
}



