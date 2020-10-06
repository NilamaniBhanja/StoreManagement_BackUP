using System.Linq;
using StoreManagement.Core.Data;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class SupplierRepository : RepositoryAsync<Supplier>, ISupplierRepository
    {
         private readonly StoreDbContext _db;

        public SupplierRepository(StoreDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Supplier supplier)
        {
            var objFromDb = _db.Supplier.FirstOrDefault(s => s.Id == supplier.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = supplier.Name;
                objFromDb.SupplierType = supplier.SupplierType;
                objFromDb.BusinessType = supplier.BusinessType;
                objFromDb.Address = supplier.Address;
            }
        }
    }
}