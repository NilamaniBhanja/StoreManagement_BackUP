using System.Linq;
using StoreManagement.Core.Data;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class AddressRepository : RepositoryAsync<Address>, IAddressRepository
    {
        private readonly StoreDbContext _db;
        public AddressRepository(StoreDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Address address)
        {
            var objFromDb = _db.Address.FirstOrDefault(s => s.Id == address.Id);
            if (objFromDb != null)
            {
                objFromDb.Address1 = address.Address1;
                objFromDb.Address2 = address.Address2;
                objFromDb.LandMark = address.LandMark;
                objFromDb.City = address.City;
                objFromDb.State = address.State;
                objFromDb.Country = address.Country;
                objFromDb.PinCode = address.PinCode;
                objFromDb.MobileNo = address.MobileNo;
                objFromDb.LandLine = address.LandLine;
            }
        }
    }
}