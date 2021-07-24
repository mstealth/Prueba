using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Helper;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FacturaApi _api = new FacturaApi();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<FacturaData> facturas = new List<FacturaData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Factura");
            if(res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                facturas = JsonConvert.DeserializeObject<List<FacturaData>>(results);
            }
            return View(facturas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
