using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SherplexTickets.Core.Contracts;
using SherplexTickets.Infrastructure.Common;
using SherplexTickets.Infrastructure.Data.Models.MovieTheaters;

namespace SherplexTickets.Core.Services
{
    public class TheaterManagerService : ITheaterManagerService
    {

        private readonly IRepository repository;
        private readonly UserManager<IdentityUser> userManager;

        public TheaterManagerService(
            IRepository repository, 
            UserManager<IdentityUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }


        public async Task<bool> ExistsТheaterМanagerByIdAsync(string userId)
        {
            
            return await repository
                .AllReadonly<TheaterManager>()
                .AnyAsync(tm => tm.UserId == userId);
            
        }

        public async Task<int?> GetТheaterМanagerIdAsync(string userId)
        {
            return (await repository
                .AllReadonly<TheaterManager>()
                .FirstOrDefaultAsync(p => p.UserId == userId))?.Id;
        }


        public async Task<string?> GetUserIdTheaterManagerByEmailAsync(string emailManager)
        {
            var user = await userManager.FindByEmailAsync(emailManager);
            return user?.Id;
        }
    }
}
