using ApiSqlAsp.DataContext;
using ApiSqlAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSqlAsp.Controllers
{
    public class ClienteControllers : ControllerBase
    {
        [HttpGet("cliente")]
        public async Task<IActionResult> GetAsync([FromServices] ApiDataContext context)
        {
            var cliente = await context.Clientes.ToListAsync();
            return Ok(cliente);
        }

        [HttpGet("cliente/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var client = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if(client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost("cliente")]
        public async Task<IActionResult> Post(
            [FromServices] ApiDataContext context,
            [FromBody] Cliente cliente)
        {
            await context.Clientes.AddAsync(cliente);
            context.SaveChanges();

            return Created($"cliente/{cliente.Id}",cliente);
        }

        [HttpPut("cliente/{id:int}")]
        public async Task<IActionResult> Put(
            [FromServices] ApiDataContext context,
            [FromRoute] int id,
            [FromBody] Cliente cliente)
        {
            var client = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound();

            client.Nome = cliente.Nome;
            client.Telefone = cliente.Telefone;

            context.Clientes.Update(client);
            await context.SaveChangesAsync();

            return Ok(client);
        }

        [HttpDelete("cliente/{id:int}")]
        public async Task<IActionResult> Delete(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var client = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
                return NotFound();

            context.Clientes.Remove(client);
            await context.SaveChangesAsync();

            return Ok(client);
        }
    }
}
