using BrownNews.Models;
using System.Threading.Tasks;

namespace BrownNews.ApiClient
{
    public partial class ApiClient
    {
        public async Task<Headlines> GetHeadlinesAsync()
        {
            return await GetAsync(BaseEndpoint);
        }
    }
}
