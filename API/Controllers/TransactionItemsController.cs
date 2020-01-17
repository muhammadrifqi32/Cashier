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
    public class TransactionItemsController : ControllerBase
    {
        private ITransactionItemService _transactionItemService;

        public TransactionItemsController(ITransactionItemService transactionItemService)
        {
            _transactionItemService = transactionItemService;
        }
        [HttpGet]
        public IEnumerable<TransactionItem> Get()
        {
            return _transactionItemService.Get();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "GetTransactionItems")]
        public IActionResult Get(int id)
        {
            var get = _transactionItemService.Get(id);
            if (get != null)
            {
                return Ok(get);
            }
            return BadRequest("Added Row Failed!");
        }

        // POST: api/Departments
        [HttpPost]
        public IActionResult Post(TransactionItemVM transactionItemVM)
        {
            var push = _transactionItemService.Create(transactionItemVM);
            if (push > 0)
            {
                return Ok("Successfully Added!");
            }
            return BadRequest("Added Row Failed!");
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, TransactionItemVM transactionItemVM)
        {
            var put = _transactionItemService.Update(id, transactionItemVM);
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
            var delete = _transactionItemService.Delete(id);
            if (delete > 0)
            {
                return Ok("Delete Successed!");
            }
            return BadRequest("Delete Failed!");
        }
    }
}