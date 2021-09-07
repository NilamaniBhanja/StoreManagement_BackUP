using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =  await _unitOfWork.Customer.GetAllAsync(includeProperties: "Address");
            return Ok(new { success = true, data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var result = await _unitOfWork.Customer.GetFirstOrDefaultAsync(a => a.Id == id, includeProperties: "Address");
            if (result == null)
                return NotFound(new { success = false, message = "Customer details exist in our system." });
            return Ok(new { success = true, data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _unitOfWork.Customer.
            GetFirstOrDefaultAsync(x => x.FirstName == model.FirstName && x.Address.MobileNo == model.Address.MobileNo);
            if (result != null)
            {
                ModelState.AddModelError("Name", model.FirstName + " customer is already exist.");
                return BadRequest(ModelState);
            }
            await _unitOfWork.Customer.AddAsync(model);
            _unitOfWork.Save();
            return Ok(new { success = true, message = "Data created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Customer model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _unitOfWork.Customer.GetAsync(model.Id);
            if (result == null)
                return NotFound(new { message = "Customers : " + model.Id + " not found" });
            
            _unitOfWork.Customer.Update(model);
            _unitOfWork.Save();
            return Ok(new { success = true, message = "Data updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Customer.GetAsync(id); // .GetFirstOrDefaultAsync(a => a.Id == id, includeProperties: "Address");
            if (objFromDb == null)
                return NotFound(new { success = false, message = "Customer details does not exist in our system." });
            await _unitOfWork.Customer.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            return Ok(new { success = true, message = "Data deleted successfully" });
        }
    }
}