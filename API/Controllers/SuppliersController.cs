using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services.Interface;
using Data.Model;
using Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            return _supplierService.Get();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Departments/5
        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            var get = _supplierService.Get(id);
            if (get != null)
            {
                return Ok(get);
            }
            return BadRequest("Row Not Found!");
        }

        // POST: api/Departments
        [HttpPost]
        public IActionResult Post(SupplierVM supplierVM)
        {
            var push = _supplierService.Create(supplierVM);
            if (push > 0)
            {
                return Ok("Successfully Added!");
            }
            return BadRequest("Added Row Failed!");
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, SupplierVM supplierVM)
        {
            var put = _supplierService.Update(id, supplierVM);
            if (put > 0)
            {
                return Ok("Update Sucessed!");
            }
            return BadRequest("Update Role Failed!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete = _supplierService.Delete(id);
            if (delete > 0)
            {
                return Ok("Delete Successed!");
            }
            return BadRequest("Delete Failed!");
        }
    }
}