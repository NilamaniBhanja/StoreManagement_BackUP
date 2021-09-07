using StoreManagementAPI.Models;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IProductRepository: IRepositoryAsync<Product>
    {
        void Update(Product product);
    }
}