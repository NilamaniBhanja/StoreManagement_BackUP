using StoreManagementAPI.Models;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IStoreRepository: IRepositoryAsync<Store>
    {
        void Update(Store store);
    }
}