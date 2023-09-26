using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica2.Helpers;
using PruebaTecnica2.Models;
using PruebaTecnica2.Models.DTO;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Xml.Linq;

namespace PruebaTecnica2.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsuariosDBContext db;
        private readonly string skey;

        public LoginController(UsuariosDBContext  db, IConfiguration conf)
        {
            this.db = db;
            skey = conf.GetSection("WMConfigure").GetSection("sKey").Value;
        }


        [HttpPost]
        public IActionResult Login(LoginDTO usu)
        {
            String p1 = WMCripto.Code(usu.Password);

            var ob = (from t1 in db.Usuarios 
                      join t2 in db.Roles on t1.Idrol equals t2.Id
                      where t1.Id.Equals(usu.Id) && 
                            t1.Password.Equals(p1) && 
                            t1.Estado==1 && 
                            t2.Estado==1
                      select t1).SingleOrDefault();

            if (ob != null)
            {

                var kBytes = Encoding.ASCII.GetBytes(skey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usu.Id));

                var tkDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(kBytes),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var tkHandler = new JwtSecurityTokenHandler();
                var tkConfig = tkHandler.CreateToken(tkDescriptor);

                string tk = tkHandler.WriteToken(tkConfig);
                return StatusCode(StatusCodes.Status200OK, new { token = tk });

                //return Ok(WMConvert.ConvertToUserDTO(ob));
            }
            else
                return StatusCode(
                    StatusCodes.Status401Unauthorized, new { toke = "" }
                    );
        }
    }
}
