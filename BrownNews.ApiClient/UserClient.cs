using BrownNews.Models;
using System.Threading.Tasks;

namespace BrownNews.ApiClient
{
    public partial class ApiClient
    {
        public async Task<Headlines> GetHeadlines()
        {
            return await GetAsync(BaseEndpoint);
        }
    }
}
