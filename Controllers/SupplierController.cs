using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace SupplierManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =  await _unitOfWork.Supplier.GetAllAsync(includeProperties: "Address");
            return Ok(new { success = true, data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var result = await _unitOfWork.Supplier.GetFirstOrDefaultAsync(a => a.Id == id, includeProperties: "Address");
            if (result == null)
                return NotFound(new { success = false, message = "Supplier details exist in our system." });
            return Ok(new { success = true, data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Supplier model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _unitOfWork.Supplier.GetFirstOrDefaultAsync(x => x.Name == model.Name);
            if (result != null)
            {
                ModelState.AddModelError("Name", model.Name + " supplier is already exist.");
                return BadRequest(ModelState);
            }
            await _unitOfWork.Supplier.AddAsync(model);
            _unitOfWork.Save();
            return Ok(new { success = true, message = "Data created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Supplier model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _unitOfWork.Supplier.GetAsync(model.Id);
            if (result == null)
                return NotFound(new { message = "Suppliers : " + model.Id + " not found" });

            result = await _unitOfWork.Supplier.GetFirstOrDefaultAsync(a => a.Id != model.Id && a.Name == model.Name);
            if (result != null)
            {
                ModelState.AddModelError("Name", model.Name + " supplier is already exist.");
                return BadRequest(ModelState);
            }
            _unitOfWork.Supplier.Update(model);
            _unitOfWork.Save();
            return Ok(new { success = true, message = "Data updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Supplier.GetAsync(id); // .GetFirstOrDefaultAsync(a => a.Id == id, includeProperties: "Address");
            if (objFromDb == null)
                return NotFound(new { success = false, message = "Supplier details exist in our system." });
            await _unitOfWork.Supplier.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            return Ok(new { success = true, message = "Data deleted successfully" });
        }
    }
}