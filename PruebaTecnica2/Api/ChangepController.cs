using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica2.Helpers;
using PruebaTecnica2.Models;
using PruebaTecnica2.Models.DTO;

namespace PruebaTecnica2.Api
{
    [EnableCors("Politicas")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ChangepController : ControllerBase
    {
        private readonly UsuariosDBContext db;

        public ChangepController(UsuariosDBContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public IActionResult ChangePass(UsuarioPassDTO usu)
        {
            String p1 = WMCripto.Code(usu.OldPass);
            String p2 = WMCripto.Code(usu.NewPass);

            var ob = db.Usuarios.Where(x => x.Id.Equals(usu.Id) &&
                       x.Password.Equals(p1)).SingleOrDefault();

            if (ob == null)
                return BadRequest();

            ob.Password = p2;
            db.Entry(ob).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(WMConvert.ConvertToUserDTO(ob));
        }
    }
}
