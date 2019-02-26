using BrownNews.Models;
using System.Threading.Tasks;

namespace BrownNews.ApiClient
{
    public partial class ApiClient
    {
        public async Task<News> GetNewsAsync()
        {
            return await GetAsync(BaseEndpoint);
        }
    }
}
