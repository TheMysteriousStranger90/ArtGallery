using ArtGallery.Application.Helpers;
using FluentAssertions;

namespace ArtGallery.Application.Tests.Common;

public class PaginationTests
{
    [Fact]
    public void Constructor_SetsAllProperties_Correctly()
    {
        var data = new List<string> { "a", "b", "c" }.AsReadOnly();

        var pagination = new Pagination<string>(pageIndex: 2, pageSize: 3, count: 10, data: data);

        pagination.PageIndex.Should().Be(2);
        pagination.PageSize.Should().Be(3);
        pagination.Count.Should().Be(10);
        pagination.Data.Should().BeEquivalentTo(data);
    }

    [Fact]
    public void Pagination_WithEmptyData_HasZeroCount()
    {
        var empty = new List<string>().AsReadOnly();

        var pagination = new Pagination<string>(1, 10, 0, empty);

        pagination.Count.Should().Be(0);
        pagination.Data.Should().BeEmpty();
    }

    [Fact]
    public void Pagination_WithSingleItem_ReturnsOneItem()
    {
        var data = new List<string> { "only" }.AsReadOnly();

        var pagination = new Pagination<string>(1, 10, 1, data);

        pagination.Data.Should().ContainSingle("only");
        pagination.Count.Should().Be(1);
    }

    [Fact]
    public void Pagination_FirstPage_HasCorrectPageIndex()
    {
        var data = new List<string>().AsReadOnly();

        var pagination = new Pagination<string>(1, 10, 0, data);

        pagination.PageIndex.Should().Be(1);
    }
}