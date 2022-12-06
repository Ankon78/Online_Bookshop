using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ReportRepo : IRepo<Report, int, Report>
    {

        BookshopEntities db;
        public ReportRepo()
        {
            db = new BookshopEntities();
        }

        public Report Add(Report obj)
        {
            db.Reports.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var Report = db.Reports.Find(id);
            db.Reports.Remove(Report);
            return db.SaveChanges() > 0;
        }

        public List<Report> Get()
        {
            var data = db.Reports.ToList();
            return data;
        }

        public Report Get(int id)
        {
            return db.Reports.Find(db.Reports.Find(id));
        }
        public bool Update(Report obj)
        {
            var ext = db.Reports.Find(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
