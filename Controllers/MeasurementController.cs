using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Models;
using StoreManagementAPI.Models;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly StoreContext _dbContext;
        public MeasurementController(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _dbContext.Measurements.ToListAsync();
            return Ok(model);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this._dbContext.Measurements.FindAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Measurement model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await this._dbContext.Measurements.AnyAsync(x => x.Name == model.Name);
            if (result)
            {
                ModelState.AddModelError("errors", model.Name + " measurement is already exist.");
                return BadRequest(ModelState);
            }
            this._dbContext.Measurements.Add(model);
            var res = await this._dbContext.SaveChangesAsync();
 
            return Ok(res);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Measurement model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await this._dbContext.Measurements.FindAsync(id);
            if (result == null)
                return NotFound(new { message = "Measurements : "+id+ " not found" });
            model.id=id;
            this._dbContext.Entry(result).CurrentValues.SetValues(model);
            var res = await this._dbContext.SaveChangesAsync();
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Measurementmodel = await this._dbContext.Measurements.FindAsync(id);
            if (Measurementmodel == null)
                return NotFound();
             this._dbContext.Measurements.Remove(Measurementmodel);
            var result = await this._dbContext.SaveChangesAsync();
            return Ok(result);
        }
    }
}