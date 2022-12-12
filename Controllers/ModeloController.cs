using ApiSqlAsp.DataContext;
using ApiSqlAsp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSqlAsp.Controllers
{
    [ApiController]
    public class ModeloController : ControllerBase
    {
        //Métodos detro de Controllers São chamados de Actions
        [HttpGet("modelo")]
        public IActionResult Get([FromServices]ApiDataContext context)
        {
            return Ok(context.Modelos.ToList());
        }

        [HttpGet("modelo/{id:int}")]
        public IActionResult GetById(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var model = context.Modelos.FirstOrDefault(x => x.Id == id);
            if(model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost("modelo")]
        public IActionResult Post(
            [FromServices] ApiDataContext context, 
            [FromBody]Modelo model)
        {
            context.Modelos.Add(model);
            context.SaveChanges();

            return Created($"/{model.Id}",model);
        }

        [HttpPut("modelo/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromServices] ApiDataContext context,
            [FromBody] Modelo model)
        {
            var modelo = context.Modelos.FirstOrDefault(x => x.Id == id);
            if(modelo == null)
                return NotFound();

            modelo.Nome = model.Nome;
            modelo.Ano = model.Ano;
            modelo.Cor = model.Cor;

            context.Modelos.Update(modelo);
            context.SaveChanges();
            return Ok(modelo);
        }

        [HttpDelete("modelo/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] ApiDataContext context)
        {
            var modelo = context.Modelos.FirstOrDefault(x => x.Id == id);
            if (modelo == null)
                return NotFound();

            context.Modelos.Remove(modelo);
            context.SaveChanges();
            return Ok(modelo);
        }
    }
}
