using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
        Task<IEnumerable<User>> GetUsers();

    }
}
