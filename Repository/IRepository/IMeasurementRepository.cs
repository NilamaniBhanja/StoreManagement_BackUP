using StoreManagementAPI.Models;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IMeasurementRepository: IRepositoryAsync<Measurement>
    {
        void Update(Measurement measurement);
    }
}