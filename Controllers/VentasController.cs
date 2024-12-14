using Microsoft.AspNetCore.Mvc;
using ProductCategoryCrud.Models;
using ProductCategoryCrud.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCategoryCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VentaController(AppDbContext context)
        {
            _context = context;
        }

        private static List<Ventas> _ventas = new List<Ventas>();

        // GET: api/ventas
        [HttpGet]
        public ActionResult<IEnumerable<Ventas>> GetVentas()
        {
            // Retorna todas las ventas
            return Ok(_ventas);
        }

        // POST: api/ventas
        [HttpPost]
        public ActionResult<Ventas> CreateVenta(Ventas venta)
        {
            // Aquí podemos agregar lógica para validar o procesar la venta antes de agregarla
            if (venta == null || venta.VentasItems == null || !venta.VentasItems.Any())
            {
                return BadRequest("La venta o los ítems de la venta no son válidos.");
            }

            // Asignar un Id único (por ejemplo, podríamos usar un contador o el Id puede ser generado automáticamente en la base de datos)
            venta.Id = _ventas.Count + 1;

            // Agregar la venta a la lista en memoria
            _ventas.Add(venta);

            // Devolver un resultado exitoso con el recurso creado
            return CreatedAtAction(nameof(GetVentas), new { id = venta.Id }, venta);
        }
    }
}
