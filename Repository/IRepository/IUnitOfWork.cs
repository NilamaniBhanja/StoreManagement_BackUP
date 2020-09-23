using System;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IBrandRepository Brand { get; }
        void Save();
    }
}