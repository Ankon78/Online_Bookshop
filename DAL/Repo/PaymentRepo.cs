using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class PaymentRepo : IRepo<Payment, int, Payment>
    {

        BookshopEntities db;
        public PaymentRepo()
        {
            db = new BookshopEntities();
        }

        public Payment Add(Payment obj)
        {
            db.Payments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var Payment = db.Payments.Find(id);
            db.Payments.Remove(Payment);
            return db.SaveChanges() > 0;
        }

        public List<Payment> Get()
        {
            var data = db.Payments.ToList();
            return data;
        }

        public Payment Get(int id)
        {
            return db.Payments.Find(db.Payments.Find(id));
        }
        public bool Update(Payment obj)
        {
            var ext = db.Payments.Find(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    

    }
}
