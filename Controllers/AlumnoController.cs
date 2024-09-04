using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FJCO20240903.Models;
using Microsoft.AspNetCore.Mvc;

namespace FJCO20240903.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : ControllerBase
    {
        static List<Alumno> alumnos = new List<Alumno>();

        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }
        
        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(c => c.Id == id);
            return alumno;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var alumnoToUpdate = alumnos.FirstOrDefault(c => c.Id == id);
            if (alumnoToUpdate != null)
            {
                alumnoToUpdate.Nombre = alumno.Nombre;
                alumnoToUpdate.Apellido = alumno.Apellido;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alumnoToDelete = alumnos.FirstOrDefault(c => c.Id == id);
            if (alumnoToDelete != null)
            {
                alumnos.Remove(alumnoToDelete);
                return Ok();
            }
            else
            {
                return NotFound();
             }
         }
    }
}