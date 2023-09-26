using Microsoft.EntityFrameworkCore;
using PruebaTecnica2.Helpers;
using PruebaTecnica2.Models;
using PruebaTecnica2.Models.DTO;
using PruebaTecnica2.Services.Interfaces;

namespace PruebaTecnica2.Services
{
    public class UsuariosServices : ICrud<Usuario,UsuarioDTO>
    {
        private readonly UsuariosDBContext db; 

        public UsuariosServices(UsuariosDBContext  db) 
        {
            this.db = db;
        }

        public UsuarioDTO Add(Usuario ob)
        {
            db.Add(ob);
            db.SaveChanges();
            return GetById(ob.Id);
        }

        public UsuarioDTO Delete(object id)
        {
            var  x =  GetById(id);
            if(x != null)
            {
                db.Usuarios.Remove(WMConvert.ConvertToUser(x));
                db.SaveChanges();
            }
            return x;
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var ls =  (from t1 in db.Usuarios
                      join t2 in db.Roles
                      on t1.Idrol equals t2.Id
                      select new UsuarioDTO()
                      {
                          Id = t1.Id,
                          Nombre = t1.Nombre,
                          Estado = t1.Estado,
                          IdRol = t2.Id,
                          NombreRol = t2.Nombre
                      }).ToList();
            return ls;
        }

        public UsuarioDTO GetById(object id)
        {
            String nId=id.ToString();

            var ob = (from t1 in db.Usuarios
                      join t2 in db.Roles
                      on t1.Idrol equals t2.Id
                      where t1.Id.Equals(nId)
                      select new UsuarioDTO()
                      {
                          Id = t1.Id,
                          Nombre = t1.Nombre,
                          Estado = t1.Estado,
                          IdRol = t2.Id,
                          NombreRol = t2.Nombre
                      }).SingleOrDefault();
            return ob;
        }

        public UsuarioDTO Update(Usuario ob)
        {
            var x = db.Usuarios.Find(ob.Id);
            if (x == null)
                return null;

            ob.Password = x.Password;
            db.Entry(x).CurrentValues.SetValues(ob);
            db.SaveChanges();
            return GetById(ob.Id);;
        }
    }
}
