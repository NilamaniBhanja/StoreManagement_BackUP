using StoreManagement.Core.Data;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _db;
        public IAddressRepository Address { get; private set; }
        public IBrandRepository Brand { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public IMeasurementRepository Measurement { get; private set; }
        public IProductRepository Product { get; private set; }
        public IProductCostRepository ProductCost { get; private set; }
        public IStoreRepository Store { get; private set; }
        public ISupplierRepository Supplier { get; private set; }        
        public UnitOfWork(StoreDbContext db)
        {
            _db = db;
            Address = new AddressRepository(_db);
            Brand = new BrandRepository(_db);
            Category = new CategoryRepository(_db);
            Customer = new CustomerRepository(_db);
            Measurement = new MeasurementRepository(_db);
            Product = new ProductRepository(_db);
            ProductCost = new ProductCostRepository(_db);
            Supplier = new SupplierRepository(_db);
            Store = new StoreRepository(_db);
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