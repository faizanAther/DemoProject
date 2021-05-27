using EmployeeCRUDWebApp.Helper;
using EmployeeCRUDWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeCRUDWebApp.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeApiHelper apiHelper = new EmployeeApiHelper();
        public async Task<IActionResult> Index()
        {
            List<EmployeeData> employees = new List<EmployeeData>();
            System.Net.Http.HttpClient client = apiHelper.Initial();
            System.Net.Http.HttpResponseMessage res = await client.GetAsync("api/employee");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<EmployeeData>>(results);
            }
            return View(employees);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var employee = new EmployeeData();
            System.Net.Http.HttpClient client = apiHelper.Initial();
            System.Net.Http.HttpResponseMessage res = await client.GetAsync($"api/employee/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<EmployeeData>(results);
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeData employee)
        {

            HttpClient client = apiHelper.Initial();

            var postTask = client.PostAsJsonAsync<EmployeeData>("api/employee", employee);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = new EmployeeData();
            HttpClient client = apiHelper.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/employee/{id}");

            return RedirectToAction("Index");
        }



    }
}
