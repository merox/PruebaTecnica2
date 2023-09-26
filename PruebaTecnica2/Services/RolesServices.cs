using Microsoft.EntityFrameworkCore;
using PruebaTecnica2.Models;
using PruebaTecnica2.Services.Interfaces;

namespace PruebaTecnica2.Services
{
    public class RolesServices: ICrud<Role, Role>
    {
        private readonly UsuariosDBContext db;

        public RolesServices(UsuariosDBContext db)
        {
            this.db = db;
        }

        public Role Add(Role ob)
        {
            db.Roles.Add(ob);
            db.SaveChanges();
            return ob;
        }

        public Role Delete(object id)
        {
            var x = db.Roles.Find(id);
            if (x == null)
                return null;            
            db.Roles.Remove(x);
            db.SaveChanges();
            return x;
            
        }

        public  IEnumerable<Role> GetAll()
        {
            var ls=db.Roles.ToList();
            return ls;
        }

        public Role GetById(object id)
        {
            var x =  db.Roles.Find(id);
            return x;
        }

        public Role Update(Role ob)
        {
            var x = db.Roles.Find(ob.Id);
            if (x == null)
                return null;

            db.Entry(x).CurrentValues.SetValues(ob);
            db.SaveChanges();
            return ob;
        }
    }
}
