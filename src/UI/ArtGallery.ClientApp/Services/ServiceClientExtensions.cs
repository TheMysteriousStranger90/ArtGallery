// Hand-written extensions for endpoints added after NSwag client was generated.
// This file extends the partial IClient interface and Client class from ServiceClient.cs.
using System.Text;
using System.Text.Json;

#pragma warning disable 1591

namespace ArtGallery.ClientApp.Services;

// DTO for Tags management (not in the generated client)
[System.CodeDom.Compiler.GeneratedCode("Manual", "1.0")]
public partial class TagDto
{
    [System.Text.Json.Serialization.JsonPropertyName("id")]
    public System.Guid Id { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

public partial interface IClient
{
    // --- Favorites: Remove ---
    System.Threading.Tasks.Task RemovePaintingFromFavoritesAsync(System.Guid paintingId, string apiVersion, System.Threading.CancellationToken cancellationToken = default);
    System.Threading.Tasks.Task RemoveArtistFromFavoritesAsync(System.Guid artistId, string apiVersion, System.Threading.CancellationToken cancellationToken = default);

    // --- Tags ---
    System.Threading.Tasks.Task<System.Collections.Generic.ICollection<TagDto>> TagsGETAllAsync(string apiVersion, System.Threading.CancellationToken cancellationToken = default);
    System.Threading.Tasks.Task<TagDto> TagsGETByIdAsync(System.Guid id, string apiVersion, System.Threading.CancellationToken cancellationToken = default);
    System.Threading.Tasks.Task<TagDto> TagsPOSTAsync(string apiVersion, string name, System.Threading.CancellationToken cancellationToken = default);
    System.Threading.Tasks.Task<TagDto> TagsPUTAsync(System.Guid id, string apiVersion, string name, System.Threading.CancellationToken cancellationToken = default);
    System.Threading.Tasks.Task TagsDELETEByIdAsync(System.Guid id, string apiVersion, System.Threading.CancellationToken cancellationToken = default);
}

public partial class Client
{
    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    private string BuildUrl(string path, string apiVersion)
        => $"{_baseUrl}{path}?api-version={Uri.EscapeDataString(apiVersion)}";

    private static async Task EnsureSuccessAsync(System.Net.Http.HttpResponseMessage response, System.Threading.CancellationToken cancellationToken)
    {
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            throw new ApiException($"HTTP {(int)response.StatusCode}", (int)response.StatusCode, body, null, null);
        }
    }

    // Remove painting from favorites
    public async System.Threading.Tasks.Task RemovePaintingFromFavoritesAsync(
        System.Guid paintingId, string apiVersion, System.Threading.CancellationToken cancellationToken = default)
    {
        var url = BuildUrl($"api/paintings/paintings/{Uri.EscapeDataString(paintingId.ToString())}", apiVersion);
        using var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Delete, url);
        PrepareRequest(_httpClient, request, url);
        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        await EnsureSuccessAsync(response, cancellationToken).ConfigureAwait(false);
    }

    // Remove artist from favorites
    public async System.Threading.Tasks.Task RemoveArtistFromFavoritesAsync(
        System.Guid artistId, string apiVersion, System.Threading.CancellationToken cancellationToken = default)
    {
        var url = BuildUrl($"api/artists/artists/{Uri.EscapeDataString(artistId.ToString())}", apiVersion);
        using var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Delete, url);
        PrepareRequest(_httpClient, request, url);
        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        await EnsureSuccessAsync(response, cancellationToken).ConfigureAwait(false);
    }

    // Get all tags
    public async System.Threading.Tasks.Task<System.Collections.Generic.ICollection<TagDto>> TagsGETAllAsync(
        string apiVersion, System.Threading.CancellationToken cancellationToken = default)
    {
        var url = BuildUrl("api/tags", apiVersion);
        using var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        PrepareRequest(_httpClient, request, url);
        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        await EnsureSuccessAsync(response, cancellationToken).ConfigureAwait(false);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<List<TagDto>>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false)
               ?? new List<TagDto>();
    }

    // Get tag by id
    public async System.Threading.Tasks.Task<TagDto> TagsGETByIdAsync(
        System.Guid id, string apiVersion, System.Threading.CancellationToken cancellationToken = default)
    {
        var url = BuildUrl($"api/tags/{Uri.EscapeDataString(id.ToString())}", apiVersion);
        using var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        PrepareRequest(_httpClient, request, url);
        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        await EnsureSuccessAsync(response, cancellationToken).ConfigureAwait(false);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<TagDto>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false)
               ?? new TagDto();
    }

    // Create tag
    public async System.Threading.Tasks.Task<TagDto> TagsPOSTAsync(
        string apiVersion, string name, System.Threading.CancellationToken cancellationToken = default)
    {
        var url = BuildUrl("api/tags", apiVersion);
        var body = JsonSerializer.Serialize(new { name });
        using var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, url);
        request.Content = new System.Net.Http.StringContent(body, Encoding.UTF8, "application/json");
        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        PrepareRequest(_httpClient, request, url);
        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        await EnsureSuccessAsync(response, cancellationToken).ConfigureAwait(false);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<TagDto>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false)
               ?? new TagDto();
    }

    // Update tag
    public async System.Threading.Tasks.Task<TagDto> TagsPUTAsync(
        System.Guid id, string apiVersion, string name, System.Threading.CancellationToken cancellationToken = default)
    {
        var url = BuildUrl($"api/tags/{Uri.EscapeDataString(id.ToString())}", apiVersion);
        var body = JsonSerializer.Serialize(new { id, name });
        using var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Put, url);
        request.Content = new System.Net.Http.StringContent(body, Encoding.UTF8, "application/json");
        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        PrepareRequest(_httpClient, request, url);
        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        await EnsureSuccessAsync(response, cancellationToken).ConfigureAwait(false);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<TagDto>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false)
               ?? new TagDto();
    }

    // Delete tag
    public async System.Threading.Tasks.Task TagsDELETEByIdAsync(
        System.Guid id, string apiVersion, System.Threading.CancellationToken cancellationToken = default)
    {
        var url = BuildUrl($"api/tags/{Uri.EscapeDataString(id.ToString())}", apiVersion);
        using var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Delete, url);
        PrepareRequest(_httpClient, request, url);
        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        await EnsureSuccessAsync(response, cancellationToken).ConfigureAwait(false);
    }
}