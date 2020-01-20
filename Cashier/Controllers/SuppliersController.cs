using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Client.Base;
using Data.Model;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public JsonResult InsertOrUpdate(SupplierVM supplierVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var myContent = JsonConvert.SerializeObject(supplierVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (supplierVM.Id == 0)
            {
                var result = client.PostAsync("Suppliers", byteContent).Result;
                return Json(result);
            }
            else
            {
                var result = client.PutAsync("Suppliers/" + supplierVM.Id, byteContent).Result;
                return Json(result);
            }
        }

        public JsonResult GetById(int id)
        {
            Supplier supplier = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var responseTask = client.GetAsync("Suppliers/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Supplier>();
                readTask.Wait();
                supplier = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(supplier);
        }

        //public async Task<JsonResult> GetById(int id)
        //{
        //    var client = new HttpClient
        //    {
        //        BaseAddress = new Uri(getPort.client)
        //    };
        //    HttpResponseMessage response = await client.GetAsync("Suppliers/" + id);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var data = await response.Content.ReadAsAsync<IList<Supplier>>();
        //        var item = data.FirstOrDefault(s => s.Id == id);
        //        var json = JsonConvert.SerializeObject(item, Formatting.None, new JsonSerializerSettings()
        //        {
        //            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //        });
        //        return Json(json);
        //    }
        //    return Json("internal server error");
        //}

        public JsonResult Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(getPort.client)
            };
            var result = client.DeleteAsync("Suppliers/" + id).Result;
            return Json(result);
        }
    }
}