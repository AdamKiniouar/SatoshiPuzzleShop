using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Repositories
{
    public class UserRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;

        public UserRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }



        public async Task<User> GetUser(int userId)
        {
            var category = await shopOnlineDbContext.Users.SingleOrDefaultAsync(c => c.Id == userId);
            return category;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var categories = await shopOnlineDbContext.Users.ToListAsync();

            return categories;

        }
    }
}
