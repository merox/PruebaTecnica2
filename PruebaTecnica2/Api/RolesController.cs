using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica2.Models;
using PruebaTecnica2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica2.Api
{
    [EnableCors("Politicas")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private RolesServices ser;

        public RolesController(UsuariosDBContext db)
        {
            ser = new RolesServices(db);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ser.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var x = ser.GetById(id);
            if (x == null)
                return BadRequest();

            return Ok(x);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Role ob)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var x=ser.Add(ob); 
            return Ok(x);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Role ob)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (id != ob.Id)
                return BadRequest("No coinciden el ID");

            var x = ser.Update(ob);
            if (x == null)
                return BadRequest();

            return Ok(x);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var x = ser.Delete(id);
            if (x == null)
                return BadRequest();

            return Ok(x);
        }
    }
}
