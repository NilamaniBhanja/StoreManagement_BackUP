using StoreManagementAPI.Models;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IProductCostRepository: IRepositoryAsync<ProductCost>
    {
        void Update(ProductCost productCost);
    }
}