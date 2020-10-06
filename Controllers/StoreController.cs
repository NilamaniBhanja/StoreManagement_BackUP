using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Core.Data;
using StoreManagementAPI.Models;
using StoreManagementAPI.Repository.IRepository;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        // private readonly IUnitOfWork _unitOfWork;
        // public StoreController(IUnitOfWork unitOfWork)
        // {
        //     _unitOfWork = unitOfWork;
        // }

        // [HttpGet]
        // public async Task<IActionResult> Get()
        // {
        //     var result =  await _unitOfWork.Store.GetAllAsync(includeProperties: "Address");
        //     return Ok(new { success = true, data = result });
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> Get(int id)
        // {

        //     var result = await _unitOfWork.Store.GetFirstOrDefaultAsync(a => a.Id == id, includeProperties: "Address");
            
        //     //var result = await _unitOfWork.Store.GetFirstOrDefaultAsync(a => a.Id == id, includeProperties: "Address");
        //     if (result == null)
        //         return NotFound(new { success = false, message = "Store details exist in our system." });
        //     return Ok(new { success = true, data = result });
        // }

        // [HttpPost]
        // public async Task<IActionResult> Post(Store model)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //     var result = await _unitOfWork.Store.GetFirstOrDefaultAsync(x => x.Name == model.Name);
        //     if (result != null)
        //     {
        //         ModelState.AddModelError("Name", model.Name + " store is already exist.");
        //         return BadRequest(ModelState);
        //     }
        //     await _unitOfWork.Store.AddAsync(model);
        //     _unitOfWork.Save();
        //     return Ok(new { success = true, message = "Data created successfully" });
        // }

        // [HttpPut]
        // public async Task<IActionResult> Put([FromBody] Store model)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     var result = await _unitOfWork.Store.GetAsync(model.Id);
        //     if (result == null)
        //         return NotFound(new { message = "Stores : " + model.Id + " not found" });

        //     result = await _unitOfWork.Store.GetFirstOrDefaultAsync(a => a.Id != model.Id && a.Name == model.Name);
        //     if (result != null)
        //     {
        //         ModelState.AddModelError("Name", model.Name + " store is already exist.");
        //         return BadRequest(ModelState);
        //     }
        //     _unitOfWork.Store.Update(model);
        //     _unitOfWork.Save();
        //     return Ok(new { success = true, message = "Data updated successfully" });
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var objFromDb = await _unitOfWork.Store.GetAsync(id); // .GetFirstOrDefaultAsync(a => a.Id == id, includeProperties: "Address");
        //     if (objFromDb == null)
        //         return NotFound(new { success = false, message = "Store details exist in our system." });
        //     await _unitOfWork.Store.RemoveAsync(objFromDb);
        //     _unitOfWork.Save();

        //     return Ok(new { success = true, message = "Data deleted successfully" });
        // }
    }
}