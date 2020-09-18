using Microsoft.AspNetCore.Mvc;
using StoreManagement.Core.Data;

namespace StoreManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly StoreDbContext _dbContext;
        public BrandController(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // [HttpGet]
        // public async Task<IActionResult> Get()
        // {
        //     var model = await _dbContext.Brands.ToListAsync();
        //     return Ok(model);
        // }
        // [HttpGet("{id}")]
        // public async Task<IActionResult> Get(int id)
        // {
        //     var result = await this._dbContext.Brands.FindAsync(id);
        //     if (result == null)
        //         return NotFound();
        //     return Ok(result);
        // }
        // [HttpPost]
        // public async Task<IActionResult> Post([FromBody] Brand model)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //     var result = await this._dbContext.Brands.AnyAsync(x => x.Name == model.Name);
        //     if (result)
        //     {
        //         ModelState.AddModelError("errors", model.Name + " brand is already exist.");
        //         return BadRequest(ModelState);
        //     }
        //     this._dbContext.Brands.Add(model);
        //     var res = await this._dbContext.SaveChangesAsync();
 
        //     return Ok(res);
        // }
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(int id, [FromBody] Brand model)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     var result = await this._dbContext.Brands.FindAsync(id);
        //     if (result == null)
        //         return NotFound(new { message = "Brands : "+id+ " not found" });
        //     // this._dbContext.Brands.Attach(model);
        //     // this._dbContext.Entry(model).State = EntityState.Modified;
        //      model.id=id;
        //     this._dbContext.Entry(result).CurrentValues.SetValues(model);
        //     var res = await this._dbContext.SaveChangesAsync();
        //     return Ok(res);
        // }
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var brandmodel = await this._dbContext.Brands.FindAsync(id);
        //     if (brandmodel == null)
        //         return NotFound();
        //      this._dbContext.Brands.Remove(brandmodel);
        //     var result = await this._dbContext.SaveChangesAsync();
        //     return Ok(result);
        // }
    }
}