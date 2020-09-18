using StoreManagement.Core.Data;
using StoreManagement.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly StoreDbContext _db;

        public UnitOfWork(StoreDbContext db)
        {
            _db = db;         
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}