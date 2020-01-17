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
    public class ItemsController : ControllerBase
    {
        private IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _itemService.Get();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "GetItems")]
        public IActionResult Get(int id)
        {
            var get = _itemService.Get(id);
            if (get != null)
            {
                return Ok(get);
            }
            return BadRequest("Added Row Failed!");
        }

        // POST: api/Departments
        [HttpPost]
        public IActionResult Post(ItemVM itemVM)
        {
            var push = _itemService.Create(itemVM);
            if (push > 0)
            {
                return Ok("Successfully Added!");
            }
            return BadRequest("Added Row Failed!");
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ItemVM itemVM)
        {
            var put = _itemService.Update(id, itemVM);
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
            var delete = _itemService.Delete(id);
            if (delete > 0)
            {
                return Ok("Delete Successed!");
            }
            return BadRequest("Delete Failed!");
        }
    }
}