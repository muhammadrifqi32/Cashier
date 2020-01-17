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
    public class TransactionsController : ControllerBase
    {
        private ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return _transactionService.Get();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "GetTransactions")]
        public IActionResult Get(int id)
        {
            var get = _transactionService.Get(id);
            if (get != null)
            {
                return Ok(get);
            }
            return BadRequest("Added Row Failed!");
        }

        // POST: api/Departments
        [HttpPost]
        public IActionResult Post(TransactionVM transactionVM)
        {
            var push = _transactionService.Create(transactionVM);
            if (push > 0)
            {
                return Ok("Successfully Added!");
            }
            return BadRequest("Added Row Failed!");
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, TransactionVM transactionVM)
        {
            var put = _transactionService.Update(id, transactionVM);
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
            var delete = _transactionService.Delete(id);
            if (delete > 0)
            {
                return Ok("Delete Successed!");
            }
            return BadRequest("Delete Failed!");
        }
    }
}