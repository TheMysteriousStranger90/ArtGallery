using ArtGallery.Domain.Entities.Enums;

namespace ArtGallery.Application.Specifications;

public class PaintingSpecParams
{
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;

    private int _pageSize = 9;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    
    public Guid? ArtistId { get; set; }
    public Guid? GenreId { get; set; }
    public Guid? MuseumId { get; set; }
    public PaintType? PaintType { get; set; }
    public int? FromYear { get; set; }
    public int? ToYear { get; set; }
    
    public string Sort { get; set; } = "title";
        
    private string _search = "";
    public string Search
    {
        get => _search;
        set => _search = value.ToLower();
    }
}