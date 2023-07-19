using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto;
using PruebaFinanzauto.Entidades;

namespace PruebaFinanzauto.Controllers
{
    [ApiController]
    [Route("api/Profesores")]
    public class ProfesoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProfesoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Profesores>>> Get()
        {
            return await context.Profesores.ToListAsync();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post(Profesores profesor)
        {
            context.Add(profesor);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{id:int}")] //api/Profesores/1
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(Profesores profesor, int id)
        {
            if (profesor.Id != id)
            {
                return BadRequest("El id del profesor no coincide");
            }

            context.Update(profesor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")] //api/Profesores/2
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Profesores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Estudiantes() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
