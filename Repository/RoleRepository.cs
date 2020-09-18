using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Core.Models;
using StoreManagement.Extensions;
using StoreManagement.Repository.IRepository;

namespace StoreManagement.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleRepository(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        public async Task<QueryResult<IdentityRole>> GetRole(FilteringRole filteringRole)
        {
            var result = new QueryResult<IdentityRole>();
            var query = this.roleManager.Roles.OrderBy(m => m.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filteringRole.FilterByName))
                query = query.Where(m => m.Name.ToLowerInvariant().Contains(filteringRole.FilterByName));

            var columnsMap = new Dictionary<string, Expression<Func<IdentityRole, object>>>()
            {
                ["Name"] = v => v.Name,
                ["NormalizedName"] = v => v.NormalizedName
            };
            query = query.ApplyOrdering<IdentityRole>(filteringRole.SortBy, filteringRole.IsSortAscending, columnsMap);
            result.TotalItems = query.Count();
            query = query.ApplyPaging(filteringRole.Page, filteringRole.PageSize);
            result.Items = await query.ToListAsync();
            return result;
        }
    }
}