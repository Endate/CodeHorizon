using Microsoft.AspNetCore.Identity;

namespace CodeHorizon.Web.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
