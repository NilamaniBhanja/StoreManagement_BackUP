using System;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IBrandRepository Brand { get; }
        IMeasurementRepository Measurement { get; }
        IAddressRepository Address { get; }
        ISupplierRepository Supplier { get; }
        ICategoryRepository Category {get;}
        IProductCostRepository ProductCost {get;}
        void Save();
    }
}