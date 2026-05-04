using Microsoft.JSInterop;

namespace ArtGallery.ClientApp.Constants
{
    public static class Const
    {
        public const string DefaultApiVersion = "1.0";
        private static string _apiUrl = "https://localhost:8081/";

        public static string DefaultApiUrl
        {
            get => _apiUrl;
            set => _apiUrl = value;
        }

        public static async Task InitializeFromJsAsync(IJSRuntime jsRuntime)
        {
            try
            {
                var apiUrl = await jsRuntime.InvokeAsync<string>("eval", "window.API_BASE_URL");
                if (!string.IsNullOrEmpty(apiUrl))
                {
                    _apiUrl = apiUrl;
                }
            }
            catch
            {
            }
        }
    }
}