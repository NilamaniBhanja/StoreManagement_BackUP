using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.Brand.GetAllAsync();
            return Ok(new { success = true, data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Brand.GetAsync(id);
            if (result == null)
                return NotFound(new { success = false, message = "Brand details exist in our system." });
            return Ok(new { success = true, data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Brand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _unitOfWork.Brand.GetFirstOrDefaultAsync(x => x.Name == model.Name);
            if (result != null)
            {
                ModelState.AddModelError("Name", model.Name + " brand is already exist.");
                return BadRequest(ModelState);
            }
            await _unitOfWork.Brand.AddAsync(model);
            _unitOfWork.Save();
            return Ok(new { success = true, message = "Data created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Brand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _unitOfWork.Brand.GetAsync(model.Id);
            if (result == null)
                return NotFound(new { message = "Brands : " + model.Id + " not found" });

            result = await _unitOfWork.Brand.GetFirstOrDefaultAsync(a => a.Id != model.Id && a.Name == model.Name);
            if (result != null)
            {
                ModelState.AddModelError("Name", model.Name + " brand is already exist.");
                return BadRequest(ModelState);
            }
            _unitOfWork.Brand.Update(model);
            _unitOfWork.Save();
            return Ok(new { success = true, message = "Data updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Brand.GetAsync(id);
            if (objFromDb == null)
                return NotFound(new { success = false, message = "Brand details exist in our system." });
            
            await _unitOfWork.Brand.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            return Ok(new { success = true, message = "Data deleted successfully" });
        }
    }
}