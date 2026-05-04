namespace ArtGallery.Application.DTOs;

public class ExhibitionDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string FormattedDateRange => $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
    public string ExternalVenueAddress { get; set; }
    public string Status => GetExhibitionStatus();
        
    public MuseumBriefDto Museum { get; set; }
        
    private string GetExhibitionStatus()
    {
        var today = DateTime.Today;
        if (today < StartDate) return "Upcoming";
        if (today > EndDate) return "Past";
        return "Current";
    }
}