using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto;
using PruebaFinanzauto.Entidades;

namespace WebApi01.Controllers
{
    [ApiController]
    [Route("api/Estudiantes")]
    public class EstudiantesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EstudiantesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Estudiantes>>> Get()
        {
            return await context.Estudiantes.ToListAsync();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post(Estudiantes estudiante)
        {
            context.Add(estudiante);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{id:int}")] //api/Estudiantes/1
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(Estudiantes estudiante, int id)
        {
            if (estudiante.Id != id) {
                return BadRequest("El id del estudiante no existe");
            }

            context.Update(estudiante);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")] //api/Estudiantes/2
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(int id)
        {   
            var existe = await context.Estudiantes.AnyAsync(x => x.Id == id);
            if (!existe) { 
                return NotFound();
            }

            context.Remove(new Estudiantes() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }

    
}
