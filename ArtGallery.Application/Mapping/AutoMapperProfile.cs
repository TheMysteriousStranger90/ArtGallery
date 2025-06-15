using ArtGallery.Application.DTOs;
using ArtGallery.Application.Features.Artists.Commands;
using ArtGallery.Application.Features.Exhibitions.Commands;
using ArtGallery.Application.Features.Paintings.Commands;
using ArtGallery.Domain.Entities;
using AutoMapper;

namespace ArtGallery.Application.Mapping;

public class ArtistMappingProfile : Profile
{
    public ArtistMappingProfile()
    {
        CreateMap<Artist, ArtistDto>()
            .ForMember(d => d.PictureUrl, o => o.MapFrom(s => 
                s.ArtistImage.FirstOrDefault(i => i.IsMain)!.PictureUrl ?? ""));
                
        CreateMap<Artist, ArtistDetailDto>();
        CreateMap<Biography, BiographyDto>();
        CreateMap<ArtistImage, ArtistImageDto>();
        CreateMap<Painting, PaintingListDto>();
            
        CreateMap<Artist, CreateArtistDto>();
            
        CreateMap<CreateArtistCommand, Artist>();
        CreateMap<UpdateArtistCommand, Artist>();
        
        CreateMap<Artist, ArtistDto>()
            .ForMember(d => d.PictureUrl, o => o.MapFrom(s => 
                s.ArtistImage.FirstOrDefault(i => i.IsMain).PictureUrl ?? ""));
        
        CreateMap<Artist, ArtistDetailDto>()
            .ForMember(d => d.PictureUrl, o => o.MapFrom(s => 
                s.ArtistImage.FirstOrDefault(i => i.IsMain).PictureUrl ?? ""));
        
        CreateMap<Painting, PaintingDto>()
            .ForMember(d => d.Artist, o => o.MapFrom(s => s.Artist))
            .ForMember(d => d.Genre, o => o.MapFrom(s => s.Genre))
            .ForMember(d => d.Museum, o => o.MapFrom(s => s.Museum));
                
        CreateMap<Painting, PaintingDetailDto>()
            .ForMember(d => d.Images, o => o.MapFrom(s => s.PaintingImages))
            .ForMember(d => d.Tags, o => o.MapFrom(s => s.Tags.Select(t => t.Tag)))
            .ForMember(d => d.Exhibitions, o => o.MapFrom(s => s.Exhibitions.Select(e => e.Exhibition)));
                
        CreateMap<Artist, ArtistBriefDto>();
        CreateMap<Genre, GenreDto>();
        CreateMap<Museum, MuseumBriefDto>()
            .ForMember(d => d.City, o => o.MapFrom(s => s.City.Name))
            .ForMember(d => d.Country, o => o.MapFrom(s => s.City.Country.Name));
                
        CreateMap<PaintingImage, PaintingImageDto>();
        CreateMap<Tag, PaintingTagDto>();
        CreateMap<Exhibition, ExhibitionBriefDto>()
            .ForMember(d => d.MuseumName, o => o.MapFrom(s => s.Museum != null ? s.Museum.Name : s.ExternalVenueAddress));
        
        CreateMap<CreatePaintingCommand, Painting>();
        CreateMap<UpdatePaintingCommand, Painting>();
        
        CreateMap<Exhibition, ExhibitionDto>()
            .ForMember(dest => dest.Museum, opt => opt.MapFrom(src => src.Museum));
                
        CreateMap<Exhibition, ExhibitionDetailDto>()
            .ForMember(dest => dest.Paintings, opt => opt.Ignore())
            .AfterMap((src, dest) => {
                if (src.Paintings != null)
                {
                    dest.Paintings = src.Paintings.Select(pe => new ExhibitionPaintingDto
                    {
                        PaintingId = pe.PaintingId,
                        Title = pe.Painting?.Title,
                        ArtistName = pe.Painting?.Artist != null 
                            ? $"{pe.Painting.Artist.FirstName} {pe.Painting.Artist.LastName}" 
                            : "Unknown Artist",
                        CreationYear = pe.Painting?.CreationYear ?? 0,
                        ImageUrl = pe.Painting?.ImageUrl
                    }).ToList();
                }
            });
                
        CreateMap<Museum, MuseumBriefDto>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.City.Country.Name));
                
        CreateMap<Painting, ExhibitionPaintingDto>()
            .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => $"{src.Artist.FirstName} {src.Artist.LastName}"));
        
        CreateMap<CreateExhibitionCommand, Exhibition>();
        CreateMap<UpdateExhibitionCommand, Exhibition>();
        
        CreateMap<ApplicationUser, UserDto>()
            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => 
                src.UserRoles.Select(ur => ur.Role.Name).ToList()))
            .ForMember(dest => dest.FavoritePaintingsCount, opt => opt.MapFrom(src => 
                src.FavoritePaintings != null ? src.FavoritePaintings.Count : 0))
            .ForMember(dest => dest.FavoriteArtistsCount, opt => opt.MapFrom(src => 
                src.FavoriteArtists != null ? src.FavoriteArtists.Count : 0));

        
        CreateMap<UserFavoritePainting, PaintingBriefDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Painting.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Painting.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Painting.Description))
            .ForMember(dest => dest.CreationYear, opt => opt.MapFrom(src => src.Painting.CreationYear))
            .ForMember(dest => dest.Medium, opt => opt.MapFrom(src => src.Painting.Medium))
            .ForMember(dest => dest.Dimensions, opt => opt.MapFrom(src => src.Painting.Dimensions))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Painting.ImageUrl))
            .ForMember(dest => dest.PaintType, opt => opt.MapFrom(src => src.Painting.PaintType))
            .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.Painting.Artist))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Painting.Genre))
            .ForMember(dest => dest.Museum, opt => opt.MapFrom(src => src.Painting.Museum));
            
        CreateMap<UserFavoriteArtist, ArtistBriefDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Artist.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Artist.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Artist.LastName))
            .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Artist.Nationality));
            
        CreateMap<ApplicationUser, UserDetailDto>()
            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => 
                src.UserRoles.Select(ur => ur.Role.Name).ToList()))
            .ForMember(dest => dest.FavoritePaintingsCount, opt => opt.MapFrom(src => 
                src.FavoritePaintings != null ? src.FavoritePaintings.Count : 0))
            .ForMember(dest => dest.FavoriteArtistsCount, opt => opt.MapFrom(src => 
                src.FavoriteArtists != null ? src.FavoriteArtists.Count : 0))
            .ForMember(dest => dest.FavoritePaintings, opt => opt.MapFrom(src => 
                src.FavoritePaintings))
            .ForMember(dest => dest.FavoriteArtists, opt => opt.MapFrom(src => 
                src.FavoriteArtists));
        
        
        CreateMap<PaintingExhibition, ExhibitionPaintingDto>()
            .ForMember(dest => dest.PaintingId, opt => opt.MapFrom(src => src.PaintingId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Painting.Title))
            .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => $"{src.Painting.Artist.FirstName} {src.Painting.Artist.LastName}"))
            .ForMember(dest => dest.CreationYear, opt => opt.MapFrom(src => src.Painting.CreationYear))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Painting.ImageUrl));
    }
}