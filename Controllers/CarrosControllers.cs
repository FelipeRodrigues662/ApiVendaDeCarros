using ApiSqlAsp.DataContext;
using ApiSqlAsp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSqlAsp.Controllers
{
    [ApiController]
    public class CarrosController : ControllerBase
    {
        //Métodos detro de Controllers São chamados de Actions
        [HttpGet("carros")]
        public IActionResult Get([FromServices] ApiDataContext context)
        {
            return Ok(context.Cars.ToList());
        }

        [HttpGet("carros/{id:int}")]
        public IActionResult GetById(
            [FromServices] ApiDataContext context,
            [FromRoute] int id)
        {
            var caro = context.Cars.FirstOrDefault(x => x.Id == id);
            if (caro == null)
                return NotFound();

            return Ok(caro);
        }

        [HttpPost("carros")]
        public IActionResult Post(
            [FromServices] ApiDataContext context,
            [FromBody] Carros car)
        {
            context.Cars.Add(car);
            context.SaveChanges();

            return Created($"/{car.Id}", car);
        }

        [HttpPut("carros/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromServices] ApiDataContext context,
            [FromBody] Carros car)
        {
            var caro = context.Cars.FirstOrDefault(x => x.Id == id);
            if (caro == null)
                return NotFound();

            caro.ModeloId = car.ModeloId;
            caro.Valor = car.Valor;
            caro.EstadoDeVendaId = car.EstadoDeVendaId;
           
            context.Cars.Update(caro);
            context.SaveChanges();
            return Ok(caro);
        }

        [HttpDelete("carros/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] ApiDataContext context)
        {
            var caro = context.Cars.FirstOrDefault(x => x.Id == id);
            if (caro == null)
                return NotFound();

            context.Cars.Remove(caro);
            context.SaveChanges();
            return Ok(caro);
        }
    }
}
