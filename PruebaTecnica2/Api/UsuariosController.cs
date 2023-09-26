using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PruebaTecnica2.Helpers;
using PruebaTecnica2.Models;
using PruebaTecnica2.Models.DTO;
using PruebaTecnica2.Services;

namespace PruebaTecnica2.Api
{
    [EnableCors("Politicas")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private UsuariosServices ser;

        public UsuariosController(UsuariosDBContext db)
        {
            ser = new UsuariosServices(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ser.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ser.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario ob)
        {
            if(!ModelState.IsValid) 
                return BadRequest();

            ob.Password = WMCripto.Code(ob.Password);
            var x=ser.Add(ob);
            return Ok(x);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario ob)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var x= ser.Update(ob);
            if (x == null)
                return BadRequest();

            return Ok(x);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var x =ser.Delete(id);
            if (x == null)
                return BadRequest();

            return Ok(x);
        }
    }
}
