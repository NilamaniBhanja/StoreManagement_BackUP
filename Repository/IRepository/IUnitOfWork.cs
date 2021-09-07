using System;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Address { get; }
        IBrandRepository Brand { get; }
        ICategoryRepository Category {get;}
        ICustomerRepository Customer { get; }
        IMeasurementRepository Measurement { get; }        
        IProductRepository Product { get; }
        IProductCostRepository ProductCost {get;}
        IStoreRepository Store { get; }
        ISupplierRepository Supplier { get; }        
        void Save();
    }
}