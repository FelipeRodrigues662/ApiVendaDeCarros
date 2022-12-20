using ApiSqlAsp.DataContext;
using ApiSqlAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSqlAsp.Controllers
{
    [ApiController]
    [Route("v1")]
    public class CarrosController : ControllerBase
    {
        //Métodos detro de Controllers São chamados de Actions
        [HttpGet("carros")]
        public async Task<IActionResult> GetAsync([FromServices] ApiDataContext context)
        {
            var cars = await context.Cars
                .Include(x => x.Modelo)
                .Include(x => x.EstadoDeVenda)
                .Include(x => x.EstadoDeVenda.Cliente)
                .OrderBy(x => x.Valor)
                .ToListAsync();

            return Ok(cars);
        }

        [HttpGet("carros/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var caro = await context
                .Cars
                .Include(x => x.Modelo)
                .Include(x => x.EstadoDeVenda)
                .Include(x => x.EstadoDeVenda.Cliente)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (caro == null)
                return NotFound();

            return Ok(caro);
        }

        [HttpPost("carros")]
        public async Task<IActionResult> PostAsync(
            [FromServices] ApiDataContext context,
            [FromBody] Carros car)
        {
            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();

            return Created($"/{car.Id}", car);
        }

        [HttpPut("carros/{id:int}")]
        public async Task<IActionResult> Put(
            [FromRoute] int id,
            [FromServices] ApiDataContext context,
            [FromBody] Carros car)
        {
            var caro = await context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (caro == null)
                return NotFound();

            caro.ModeloId = car.ModeloId;
            caro.Valor = car.Valor;
            caro.EstadoDeVendaId = car.EstadoDeVendaId;
           
            context.Cars.Update(caro);
            await context.SaveChangesAsync();
            return Ok(caro);
        }

        [HttpDelete("carros/{id:int}")]
        public async Task<IActionResult> Delete(
            [FromRoute] int id,
            [FromServices] ApiDataContext context)
        {
            var caro = await context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (caro == null)
                return NotFound();

            context.Cars.Remove(caro);
            await context.SaveChangesAsync();
            return Ok(caro);
        }
    }
}
