using System;

namespace StoreManagementAPI.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        void Save();
    }
}