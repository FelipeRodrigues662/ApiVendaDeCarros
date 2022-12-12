using ApiSqlAsp.DataContext;
using ApiSqlAsp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSqlAsp.Controllers
{
    public class EstadoDeVendaControllers : ControllerBase
    {
        [HttpGet("venda")]
        public IActionResult Get([FromServices] ApiDataContext context)
        {
            return Ok(context.EstadoDeVendas.ToList());
        }

        [HttpGet("venda/{id:int}")]
        public IActionResult GetById(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var venda = context.EstadoDeVendas.FirstOrDefault(x => x.Id == id);
            if (venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpPost("venda")]
        public IActionResult Post(
            [FromServices] ApiDataContext context,
            [FromBody] EstadoDeVenda estadoDeVenda)
        {
            context.EstadoDeVendas.Add(estadoDeVenda);
            context.SaveChanges();

            return Created($"cliente/{estadoDeVenda.Id}", estadoDeVenda);
        }

        [HttpPut("venda/{id:int}")]
        public IActionResult Put(
            [FromServices] ApiDataContext context,
            [FromRoute] int id,
            [FromBody] EstadoDeVenda estadoDeVenda)
        {
            var sale = context.EstadoDeVendas.FirstOrDefault(x => x.Id == id);
            if (sale == null)
                return NotFound();
    
            sale.Vendido = estadoDeVenda.Vendido;
            sale.ClienteId = estadoDeVenda.ClienteId;


            context.EstadoDeVendas.Update(sale);
            context.SaveChanges();

            return Ok(sale);
        }

        [HttpDelete("venda/{id:int}")]
        public IActionResult Delete(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var sale = context.EstadoDeVendas.FirstOrDefault(x => x.Id == id);
            if (sale == null)
                return NotFound();

            context.EstadoDeVendas.Remove(sale);
            context.SaveChanges();

            return Ok(sale);
        }
    }
}
