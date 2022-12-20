using ApiSqlAsp.DataContext;
using ApiSqlAsp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSqlAsp.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ModeloController : ControllerBase
    {
        //Métodos detro de Controllers São chamados de Actions
        [HttpGet("modelo")]
        public async Task<IActionResult> GetAsync([FromServices]ApiDataContext context)
        {
            var modelo = await context.Modelos.ToListAsync();
            return Ok(modelo);
        }

        [HttpGet("modelo/{id:int}")]
        public async Task<IActionResult> GetById(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var model = await context.Modelos.FirstOrDefaultAsync(x => x.Id == id);
            if(model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost("modelo")]
        public async Task<IActionResult> Post(
            [FromServices] ApiDataContext context, 
            [FromBody]Modelo model)
        {
            await context.Modelos.AddAsync(model);
            await context.SaveChangesAsync();

            return Created($"/{model.Id}",model);
        }

        [HttpPut("modelo/{id:int}")]
        public async Task<IActionResult> Put(
            [FromRoute] int id,
            [FromServices] ApiDataContext context,
            [FromBody] Modelo model)
        {
            var modelo = await context.Modelos.FirstOrDefaultAsync(x => x.Id == id);
            if(modelo == null)
                return NotFound();

            modelo.Nome = model.Nome;
            modelo.Ano = model.Ano;
            modelo.Cor = model.Cor;

            context.Modelos.Update(modelo);
            await context.SaveChangesAsync();
            return Ok(modelo);
        }

        [HttpDelete("modelo/{id:int}")]
        public async Task<IActionResult> Delete(
            [FromRoute] int id,
            [FromServices] ApiDataContext context)
        {
            var modelo = await context.Modelos.FirstOrDefaultAsync(x => x.Id == id);
            if (modelo == null)
                return NotFound();

            context.Modelos.Remove(modelo);
            await context.SaveChangesAsync();
            return Ok(modelo);
        }
    }
}
