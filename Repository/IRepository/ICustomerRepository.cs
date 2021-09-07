using StoreManagementAPI.Models;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface ICustomerRepository: IRepositoryAsync<Customer>
    {
        void Update(Customer customer);
    }
}