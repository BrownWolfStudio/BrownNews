using BrownNews.Utilities;
using System;
using System.Threading;

namespace BrownNews.Factory
{
    public class ApiClientFactory
    {
        private static Uri apiUri;

        private static Lazy<ApiClient.ApiClient> apiClient = new Lazy<ApiClient.ApiClient>(
            () => new ApiClient.ApiClient(apiUri),
            LazyThreadSafetyMode.ExecutionAndPublication    
        );

        static ApiClientFactory() => apiUri = new Uri(ApplicationSettings.WebApiUrl);

        public static ApiClient.ApiClient Instance { get => apiClient.Value; }
    }
}
