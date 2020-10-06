using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.Category.GetAllAsync();
            return Ok(new { success = true, data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Category.GetAsync(id);
            if (result == null)
                return NotFound(new { success = false, message = "Category details exist in our system." });
            return Ok(new { success = true, data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _unitOfWork.Category.GetFirstOrDefaultAsync(x => x.Name == model.Name);
            if (result != null)
            {
                ModelState.AddModelError("Name", model.Name + " category is already exist.");
                return BadRequest(ModelState);
            }
            await _unitOfWork.Category.AddAsync(model);
            _unitOfWork.Save();
            return Ok(new { success = true, message = "Data created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Category model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _unitOfWork.Category.GetAsync(model.Id);
            if (result == null)
                return NotFound(new { message = "Categorys : " + model.Id + " not found" });

            result = await _unitOfWork.Category.GetFirstOrDefaultAsync(a => a.Id != model.Id && a.Name == model.Name);
            if (result != null)
            {
                ModelState.AddModelError("Name", model.Name + " category is already exist.");
                return BadRequest(ModelState);
            }
            _unitOfWork.Category.Update(model);
            _unitOfWork.Save();
            return Ok(new { success = true, message = "Data updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Category.GetAsync(id);
            if (objFromDb == null)
                return NotFound(new { success = false, message = "Category details exist in our system." });
            
            await _unitOfWork.Category.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            return Ok(new { success = true, message = "Data deleted successfully" });
        }
    }
}