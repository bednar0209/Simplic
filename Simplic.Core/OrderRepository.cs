using Simplic.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.Core
{
    public class OrderRepository
    {
        public static List<OrderData> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = from p in context.Orders
                            select new OrderData
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Description = p.Description,
                                Price = p.Price,
                                PersonID = p.PersonID
                            };
                return query.ToList();
            }
        }

        public static OrderData Get(int id)
        {
            return GetAll().Where(x => x.Id == id).FirstOrDefault();
        }

        public static void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var obj = context.Orders.SingleOrDefault(x => x.Id == id);
                if (obj != null)
                {
                    context.Orders.Remove(obj);
                    context.SaveChanges();
                }
            }
        }

        public static void Persist(OrderData item)
        {
            using (var context = new ApplicationDbContext())
            {
                var obj = context.Orders.FirstOrDefault(t => t.Id == item.Id) ?? new Order();
                obj.Name = item.Name;
                obj.Description = item.Description;
                obj.Price = item.Price;
                obj.PersonID = item.PersonID;
                if (obj.Id > 0)
                {
                    context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Orders.Add(obj);
                }
                context.SaveChanges();
                item.Id = obj.Id;
            }
        }
    }
}
