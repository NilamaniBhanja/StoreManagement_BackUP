using System.Linq;
using StoreManagement.Core.Data;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Repository
{
    public class MeasurementRepository : RepositoryAsync<Measurement>, IMeasurementRepository
    {
         private readonly StoreDbContext _db;

        public MeasurementRepository(StoreDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Measurement measurement)
        {
            var objFromDb = _db.Measurements.FirstOrDefault(s => s.Id == measurement.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = measurement.Name;
                objFromDb.Description = measurement.Description;
            }
        }
    }
}