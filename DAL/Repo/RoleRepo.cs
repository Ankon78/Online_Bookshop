using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class RoleRepo : IRepo<Role, int, Role>
    {
        BookshopEntities4 db;
        public RoleRepo()
        {
            db = new BookshopEntities4();
        }
        public Role Add(Role obj)
        {
            db.Roles.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var role = db.Roles.Find(id);
            db.Roles.Remove(role);
            return db.SaveChanges() > 0;
        }

        public List<Role> Get()
        {
            return db.Roles.ToList();
        }

        public Role Get(int id)
        {
            return db.Roles.Find(db.Roles.Find(id));
        }

        public bool Update(Role obj)
        {
            var ext = db.Roles.Find(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
