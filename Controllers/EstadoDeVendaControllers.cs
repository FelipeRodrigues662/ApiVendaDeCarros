using ApiSqlAsp.DataContext;
using ApiSqlAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSqlAsp.Controllers
{
    [ApiController]
    [Route("v1")]
    public class EstadoDeVendaControllers : ControllerBase
    {
        [HttpGet("venda")]
        public async Task<IActionResult> GetAsync([FromServices] ApiDataContext context)
        {
            var venda = await context.EstadoDeVendas.ToListAsync();
            return Ok(venda);
        }

        [HttpGet("venda/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var venda = await context.EstadoDeVendas.FirstOrDefaultAsync(x => x.Id == id);
            if (venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpPost("venda")]
        public async Task<IActionResult> Post(
            [FromServices] ApiDataContext context,
            [FromBody] EstadoDeVenda estadoDeVenda)
        {
            await context.EstadoDeVendas.AddAsync(estadoDeVenda);
            await context.SaveChangesAsync();

            return Created($"cliente/{estadoDeVenda.Id}", estadoDeVenda);
        }

        [HttpPut("venda/{id:int}")]
        public async Task<IActionResult> Put(
            [FromServices] ApiDataContext context,
            [FromRoute] int id,
            [FromBody] EstadoDeVenda estadoDeVenda)
        {
            var sale = await context.EstadoDeVendas.FirstOrDefaultAsync(x => x.Id == id);
            if (sale == null)
                return NotFound();
    
            sale.Vendido = estadoDeVenda.Vendido;
            sale.ClienteId = estadoDeVenda.ClienteId;


            context.EstadoDeVendas.Update(sale);
            await context.SaveChangesAsync();

            return Ok(sale);
        }

        [HttpDelete("venda/{id:int}")]
        public async Task<IActionResult> Delete(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var sale = await context.EstadoDeVendas.FirstOrDefaultAsync(x => x.Id == id);
            if (sale == null)
                return NotFound();

            context.EstadoDeVendas.Remove(sale);
            await context.SaveChangesAsync();

            return Ok(sale);
        }
    }
}
