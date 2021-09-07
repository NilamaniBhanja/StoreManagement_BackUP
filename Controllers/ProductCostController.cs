using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;
using System;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductCostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _unitOfWork.ProductCost.GetAllAsync();
            return Ok(new { success = true, data = result });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.ProductCost.GetAsync(id);
            if (result == null)
                return NotFound(new { success = false, message = "Product Cost details exist in our system." });
            return Ok(new { success = true, data = result });
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCost model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (Convert.ToDateTime(model.EffectiveDate.ToString("MM/dd/yyyy HH:mm")) < Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm")))
            {
                ModelState.AddModelError("EffectiveDate", "Effective Date should not be less than current date and time.");
                return BadRequest(ModelState);
            }
            await _unitOfWork.ProductCost.AddAsync(model);
            _unitOfWork.Save();
            return Ok(new { success = true, message = "Data created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductCost model)
        {
            string EffectiveDate = model.EffectiveDate.HasValue ? 
            model.EffectiveDate.Value.ToString("MM/dd/yyyy HH:mm") : null;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (Convert.ToDateTime(EffectiveDate) < Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:mm")))
            {
                ModelState.AddModelError("EffectiveDate", "Effective Date should not be less than current date and time.");
                return BadRequest(ModelState);
            }
            var result = await _unitOfWork.ProductCost.GetAsync(model.Id);
            if (result == null)
                return NotFound(new { success = false, message = "Product Cost details exist in our system." });

            _unitOfWork.ProductCost.Update(model);
            _unitOfWork.Save();
            return Ok(new { success = true, message = "Data updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.ProductCost.GetAsync(id);
            if (objFromDb == null)
                return NotFound(new { success = false, message = "Product Cost details exist in our system." });

            await _unitOfWork.ProductCost.RemoveAsync(objFromDb);
            _unitOfWork.Save();

            return Ok(new { success = true, message = "Data deleted successfully" });
        }
    }
}