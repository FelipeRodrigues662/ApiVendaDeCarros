using ApiSqlAsp.DataContext;
using ApiSqlAsp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSqlAsp.Controllers
{
    public class ClienteControllers : ControllerBase
    {
        [HttpGet("cliente")]
        public IActionResult Get([FromServices] ApiDataContext context)
        {
            return Ok(context.Clientes.ToList());
        }

        [HttpGet("cliente/{id:int}")]
        public IActionResult GetById(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var client = context.Clientes.FirstOrDefault(x => x.Id == id);
            if(client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost("cliente")]
        public IActionResult Post(
            [FromServices] ApiDataContext context,
            [FromBody] Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();

            return Created($"cliente/{cliente.Id}",cliente);
        }

        [HttpPut("cliente/{id:int}")]
        public IActionResult Put(
            [FromServices] ApiDataContext context,
            [FromRoute] int id,
            [FromBody] Cliente cliente)
        {
            var client = context.Clientes.FirstOrDefault(x => x.Id == id);
            if (client == null)
                return NotFound();

            client.Nome = cliente.Nome;
            client.Telefone = cliente.Telefone;

            context.Clientes.Update(client);
            context.SaveChanges();

            return Ok(client);
        }

        [HttpDelete("cliente/{id:int}")]
        public IActionResult Delete(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var client = context.Clientes.FirstOrDefault(x => x.Id == id);
            if (client == null)
                return NotFound();

            context.Clientes.Remove(client);
            context.SaveChanges();

            return Ok(client);
        }
    }
}
