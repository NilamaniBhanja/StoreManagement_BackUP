using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StoreManagement.Core.Models;

namespace StoreManagement.Repository.IRepository
{
    public interface IRoleRepository
    {
        Task<QueryResult<IdentityRole>> GetRole(FilteringRole filteringRole);
    }
}