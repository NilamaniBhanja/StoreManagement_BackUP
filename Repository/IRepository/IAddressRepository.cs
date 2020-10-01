using StoreManagementAPI.Models;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IAddressRepository: IRepositoryAsync<Address>
    {
        void Update(Address address);
    }
}