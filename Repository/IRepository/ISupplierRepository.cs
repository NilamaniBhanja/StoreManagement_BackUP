using StoreManagementAPI.Models;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface ISupplierRepository: IRepositoryAsync<Supplier>
    {
        void Update(Supplier supplier);
    }
}