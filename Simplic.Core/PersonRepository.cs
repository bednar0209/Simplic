using Simplic.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.Core
{
    public class PersonRepository
    {
        public static List<PersonData> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = from p in context.Persons
                            select new PersonData
                            {
                                Id = p.Id,
                                FirstName = p.FirstName,
                                LastName = p.LastName,
                                Address = p.Address,
                                Age = p.Age,
                                Sex = p.Sex
                            };
                return query.ToList();
            }
        }

        public static PersonData Get(int id)
        {
            return GetAll().Where(x => x.Id == id).FirstOrDefault();
        }

        public static void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var obj = context.Persons.SingleOrDefault(x => x.Id == id);
                if (obj != null)
                {
                    context.Persons.Remove(obj);
                    context.SaveChanges();
                }
            }
        }

        public static void Persist(PersonData item)
        {
            using (var context = new ApplicationDbContext())
            {
                var obj = context.Persons.FirstOrDefault(t => t.Id == item.Id) ?? new Person();
                obj.FirstName = item.FirstName;
                obj.LastName = item.LastName;
                obj.Age = item.Age;
                obj.Address = item.Address;
                obj.Sex = item.Sex;
                if (obj.Id > 0)
                {
                    context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Persons.Add(obj);
                }
                context.SaveChanges();
                item.Id = obj.Id;
            }
        }
    }
}
