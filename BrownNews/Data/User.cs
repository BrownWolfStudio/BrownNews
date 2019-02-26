using BrownNews.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace BrownNews.Data
{
    public class User : IdentityUser
    {
        [PersonalData]
        public IQueryable<Article> SavedArticles { get; set; }
    }
}
