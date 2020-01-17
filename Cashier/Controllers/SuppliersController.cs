using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Base;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class SuppliersController : Controller
    {
        Port getPort = new Base.Port();
        readonly HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            return View(List());
        }
        public JsonResult List()
        {
            IEnumerable<Supplier> suppliers = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var responseTask = client.GetAsync("Suppliers");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }
            else
            {
                suppliers = Enumerable.Empty<Supplier>();
                ModelState.AddModelError(string.Empty, "server error, try after some time");
            }
            return Json(suppliers);
        }
    }
}