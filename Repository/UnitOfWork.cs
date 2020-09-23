using StoreManagement.Core.Data;
using StoreManagement.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _db;
        public IBrandRepository Brand { get; private set; }
        public UnitOfWork(StoreDbContext db)
        {
            _db = db;
            Brand = new BrandRepository(_db);
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