using System.Linq;
using StoreManagement.Core.Data;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class CategoryRepository : RepositoryAsync<Category>, ICategoryRepository
    {
         private readonly StoreDbContext _db;

        public CategoryRepository(StoreDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;
                objFromDb.Description = category.Description;
            }
        }
    }
}