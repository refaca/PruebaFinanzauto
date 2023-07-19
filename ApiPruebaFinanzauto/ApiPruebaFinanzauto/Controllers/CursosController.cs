using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto;
using PruebaFinanzauto.Entidades;

namespace PruebaFinanzauto.Controllers
{
    [ApiController]
    [Route("api/Cursos")]
    public class CursosController : Controller
    {
        private readonly ApplicationDbContext context;

        public CursosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<Cursos>>> Get()
        {
            return await context.Cursos.ToListAsync();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post(Cursos curso)
        {
            context.Add(curso);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{id:int}")] //api/Cursos/1
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(Cursos curso, int id)
        {
            if (curso.Id != id)
            {
                return BadRequest("El id del curso no coincide");
            }

            context.Update(curso);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")] //api/Cursos/2
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Cursos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Cursos() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
