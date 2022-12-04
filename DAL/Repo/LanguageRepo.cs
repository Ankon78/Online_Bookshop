﻿using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class LanguageRepo : IRepo<Language, int, Language>
    {
        BookshopEntities4 db;

        public LanguageRepo()
        {
            db = new BookshopEntities4();
        }
        public Language Add(Language obj)
        {
            db.Languages.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var language = db.Languages.Find(id);
            db.Languages.Remove(language);
            return db.SaveChanges() > 0;
        }


        public List<Language> Get()
        {
            var data = db.Languages.ToList();
            return data;
        }

        public Language Get(int id)
        {
            return db.Languages.Find(db.Languages.Find(id));
        }

        public bool Update(Language obj)
        {
            var ext = db.Languages.Find(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
