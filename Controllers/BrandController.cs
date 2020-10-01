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
            var model = await _unitOfWork.Brand.GetAllAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Brand.GetAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Brand model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _unitOfWork.Brand.GetAsync(id);
            if (result == null)
                return NotFound(new { message = "Brands : " + id + " not found" });

            result = await _unitOfWork.Brand.GetFirstOrDefaultAsync(a => a.Id != id && a.Name == model.Name);
            if (result != null)
            {
                ModelState.AddModelError("Name", model.Name + " brand is already exist.");
                return BadRequest(ModelState);
            }
            model.Id = id;
            _unitOfWork.Brand.Update(model);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Brand.GetAsync(id);
            if (objFromDb == null)
            {
                return Ok(new { success = false, message = "Error while deleting" });
            }
            await _unitOfWork.Brand.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            return Ok(new { success = true, message = "Delete Successful" });
        }
    }
}