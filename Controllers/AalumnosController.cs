using ApiAlumnos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ApiAlumnos.Controllers
{
    [ApiController]
    [Route("alumnos")]
    public class AlumnosController: ControllerBase
    {
        private readonly ApplicationDBContext dbcontext;

        public AlumnosController(ApplicationDBContext dBContext)
        {
            this.dbcontext = dBContext;
        }
 
        [HttpGet]
        public async Task <ActionResult<List<Alumno>>> Get()
        {
            return await dbcontext.Alumnos.ToListAsync();
        }

        [HttpPost]
        public async Task <ActionResult> Post([FromBody] Alumno alumno)
        {
            dbcontext.Add(alumno);
            await dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]

        public async Task <ActionResult> Put (Alumno alumno, int id)
        {
            if(alumno.Id == id)
            {
                return BadRequest("El id del alumno no coincide con el establecido");
            }

            dbcontext.Update(alumno);
            await dbcontext.SaveChangesAsync();
            return Ok();
        }

    }
}
