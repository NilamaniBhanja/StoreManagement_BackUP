using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Core;
using StoreManagement.Core.Models;
using StoreManagement.ViewModels;

namespace StoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController: ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;        
        private readonly IRoleRepository repository;
        public RoleController(RoleManager<IdentityRole> _roleManager, IRoleRepository _repository)
        {
            roleManager = _roleManager;
            repository = _repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilteringRole filteringRole)
        {
            var model = await repository.GetRole(filteringRole);
            return Ok(model);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await this.roleManager.FindByIdAsync(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await this.roleManager.FindByNameAsync(model.Name);
            if (res != null)
            {
                ModelState.AddModelError("", model.Name + " already exist.");
                return BadRequest(ModelState);
            }
            IdentityRole role = new IdentityRole
            {
                Name = model.Name,
                NormalizedName = model.NormalizedName.ToUpper(),
                ConcurrencyStamp = DateTime.Now.ToString()
            };
            var result = await roleManager.CreateAsync(role);
            return Ok(result);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(string id, [FromBody] RoleViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await this.roleManager.Roles.FirstAsync(r => r.Id == id);
            if (result == null)
                return BadRequest();
            result.Name = model.Name;
            // result.NormalizedName = model.NormalizedName.ToUpper();
            result.ConcurrencyStamp = DateTime.Now.ToString();

            var res = await this.roleManager.UpdateAsync(result);
            return Ok(res);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var role = await this.roleManager.FindByIdAsync(Id);
            if (role == null)
                return BadRequest();
            IdentityResult result = await this.roleManager.DeleteAsync(role);
            return Ok(result);
        }
    }
}