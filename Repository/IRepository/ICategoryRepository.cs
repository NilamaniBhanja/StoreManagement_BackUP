using StoreManagementAPI.Models;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface ICategoryRepository: IRepositoryAsync<Category>
    {
        void Update(Category category);
    }
}