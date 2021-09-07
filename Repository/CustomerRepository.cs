using System.Linq;
using StoreManagement.Core.Data;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class CustomerRepository : RepositoryAsync<Customer>, ICustomerRepository
    {
         private readonly StoreDbContext _db;

        public CustomerRepository(StoreDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Customer Customer)
        {
            var objFromDb = _db.Customers.FirstOrDefault(s => s.Id == Customer.Id);
            if (objFromDb != null)
            {
                objFromDb.FirstName = Customer.FirstName;
                objFromDb.LastName = Customer.LastName;
                objFromDb.DOB = Customer.DOB;
                objFromDb.Address = Customer.Address;
            }
        }
    }
}