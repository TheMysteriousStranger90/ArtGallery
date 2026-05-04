namespace ArtGallery.Application.Contracts.Cache;

public class CacheKeyService : ICacheKeyService
{
    private readonly List<string> _cacheKeys = new List<string>();

    public void AddKey(string key)
    {
        _cacheKeys.Add(key);
    }

    public void RemoveKey(string key)
    {
        _cacheKeys.Remove(key);
    }

    public IEnumerable<string> GetKeysStartingWith(string prefix)
    {
        return _cacheKeys.Where(key => key.StartsWith(prefix)).ToList();
    }
}