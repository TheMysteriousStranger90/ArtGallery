using ArtGallery.Application.Specifications;
using FluentAssertions;

namespace ArtGallery.Domain.Tests.Specifications;

public class ArtistSpecParamsTests
{
    [Fact]
    public void ArtistSpecParams_DefaultPageIndex_IsOne()
    {
        var specParams = new ArtistSpecParams();

        specParams.PageIndex.Should().Be(1);
    }

    [Fact]
    public void ArtistSpecParams_DefaultPageSize_IsTen()
    {
        var specParams = new ArtistSpecParams();

        specParams.PageSize.Should().Be(10);
    }

    [Fact]
    public void ArtistSpecParams_PageSize_ClampsToMaximum()
    {
        var specParams = new ArtistSpecParams { PageSize = 200 };

        specParams.PageSize.Should().BeLessThanOrEqualTo(50);
    }

    [Fact]
    public void ArtistSpecParams_DefaultSort_IsLastName()
    {
        var specParams = new ArtistSpecParams();

        specParams.Sort.Should().Be("lastName");
    }

    [Fact]
    public void ArtistSpecParams_Search_NormalisesToLowerCase()
    {
        var specParams = new ArtistSpecParams { Search = "GOGH" };

        specParams.Search.Should().Be("gogh");
    }

    [Fact]
    public void ArtistSpecParams_DefaultNationality_IsNull()
    {
        var specParams = new ArtistSpecParams();

        specParams.Nationality.Should().BeNull();
    }
}
