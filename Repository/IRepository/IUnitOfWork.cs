using System;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IBrandRepository Brand { get; }
        IMeasurementRepository Measurement { get; }
        void Save();
    }
}