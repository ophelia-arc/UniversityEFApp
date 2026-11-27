using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UniversityEFApp
{
    public class CourseRepository
    {
        public List<Cours> GetAll(string sortOption = "Ada görə")
        {
            using (var db = new UniversityDBEntities())
            {
                IQueryable<Cours> query = db.Courses;

                if (sortOption == "Kreditə görə (Azalan)")
                    query = query.OrderByDescending(c => c.Credits);
                else if (sortOption == "Kreditə görə (Artan)")
                    query = query.OrderBy(c => c.Credits);
                else
                    query = query.OrderBy(c => c.CourseName);

                return query.ToList();
            }
        }

        public void Add(Cours c)
        {
            using (var db = new UniversityDBEntities())
            {
                db.Courses.Add(c);
                db.SaveChanges();
            }
        }

        public void Update(Cours c)
        {
            using (var db = new UniversityDBEntities())
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new UniversityDBEntities())
            {
                var c = db.Courses.Find(id);
                if (c == null) return;

                db.Courses.Remove(c);
                db.SaveChanges(); 
            }
        }

        public int Count()
        {
            using (var db = new UniversityDBEntities())
            {
                return db.Courses.Count();
            }
        }
    }
}