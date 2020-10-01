using System.Linq;
using StoreManagement.Core.Data;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class StoreRepository : RepositoryAsync<Store>, IStoreRepository
    {
         private readonly StoreDbContext _db;

        public StoreRepository(StoreDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Store store)
        {
            var objFromDb = _db.Store.FirstOrDefault(s => s.Id == store.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = store.Name;
                objFromDb.StoreType = store.StoreType;
                objFromDb.BusinessType = store.BusinessType;
                objFromDb.AddressId = store.AddressId;
                objFromDb.Address = store.Address;
            }
        }
    }
}