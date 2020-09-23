using StoreManagementAPI.Models;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IBrandRepository: IRepositoryAsync<Brand>
    {
        void Update(Brand brand);
    }
}