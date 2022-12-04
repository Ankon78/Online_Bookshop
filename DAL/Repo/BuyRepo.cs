using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class BuyRepo : IRepo<Buy, int, Buy>
    {
        BookshopEntities4 db;

        public BuyRepo()
        {
            db = new BookshopEntities4();   
        }

        public Buy Add(Buy obj)
        {
            db.Buys.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var buy = db.Buys.Find(id);
            db.Buys.Remove(buy);
            return db.SaveChanges() > 0;
        }

        public List<Buy> Get()
        {
            var data = db.Buys.ToList();
            return data;
        }

        public Buy Get(int id)
        {
            return db.Buys.Find(db.Buys.Find(id));
        }

        public bool Update(Buy obj)
        {
            var ext = db.Buys.Find(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
