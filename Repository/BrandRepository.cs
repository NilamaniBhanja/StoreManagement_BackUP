using System.Linq;
using StoreManagement.Core.Data;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class BrandRepository : RepositoryAsync<Brand>, IBrandRepository
    {
         private readonly StoreDbContext _db;

        public BrandRepository(StoreDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Brand brand)
        {
            var objFromDb = _db.Brands.FirstOrDefault(s => s.Id == brand.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = brand.Name;
                objFromDb.Description = brand.Description;
                objFromDb.BrandQuality = brand.BrandQuality;
            }
        }
    }
}