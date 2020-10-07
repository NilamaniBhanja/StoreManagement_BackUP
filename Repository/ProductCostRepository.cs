using System.Linq;
using StoreManagement.Core.Data;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class ProductCostRepository : RepositoryAsync<ProductCost>, IProductCostRepository
    {
         private readonly StoreDbContext _db;

        public ProductCostRepository(StoreDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductCost brand)
        {
            var objFromDb = _db.ProductCost.FirstOrDefault(s => s.Id == brand.Id);
            if (objFromDb != null)
            {
                objFromDb.ListPrice = brand.ListPrice;
                objFromDb.Price = brand.Price;
                objFromDb.Price50 = brand.Price50;
                objFromDb.Price100 = brand.Price100;
                objFromDb.EffectiveDate = brand.EffectiveDate;
            }
        }
    }
}