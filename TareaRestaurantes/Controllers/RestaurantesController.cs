using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareaRestaurantes.Data;
using TareaRestaurantes.Models;


namespace TareaRestaurantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly RestaurantesContext _context;

        public RestaurantesController(RestaurantesContext context)
        {
            _context = context;
        }

        // a) Visualizar la lista de restaurantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurantes()
        {
            return await _context.Restaurantes.ToListAsync();
        }

        // Obtener un restaurante por id (útil para el CreatedAtAction en POST)
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurante>> GetRestaurante(int id)
        {
            var restaurante = await _context.Restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }
            return restaurante;
        }

        // b) Agregar un nuevo restaurante
        [HttpPost]
        public async Task<ActionResult<Restaurante>> PostRestaurante(Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();

            // Retorna el objeto creado con la ruta para obtenerlo
            return CreatedAtAction(nameof(GetRestaurante), new { id = restaurante.Id }, restaurante);
        }

        // Opcional: Modificar un restaurante existente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurante(int id, Restaurante restaurante)
        {
            if (id != restaurante.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Opcional: Eliminar un restaurante
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurante(int id)
        {
            var restaurante = await _context.Restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            _context.Restaurantes.Remove(restaurante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestauranteExists(int id)
        {
            return _context.Restaurantes.Any(e => e.Id == id);
        }
    }
}
