using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly PruebasContext _ctx;

        public FacturaController(PruebasContext ctx)
        {
            _ctx = ctx;
        }


        [HttpGet]
        public IEnumerable<Factura> Get()
        {
            IEnumerable<Factura> facturas = _ctx.Facturas.ToList();
            return facturas;
        }

        [HttpPost]
        public IActionResult Create(Factura factura)
        {
            if (ModelState.IsValid)
            {
                _ctx.Facturas.Add(factura);
                _ctx.SaveChanges();
            }

            return Ok(factura);
        }
    }
}
