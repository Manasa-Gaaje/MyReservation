using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi1.Models;

namespace webapi1.rep
{
    public interface resInterface
    {
        string Delete(int id);
        List<resModel> GetResDetails();
        string Insert(resModel id);
        //string updateresinfo(resModel id);

        List<Sp_GetAll_Result> sp_getall();
      
        
    }

    class Details : resInterface
    {
        PottiEntities2 Pe = new PottiEntities2();



        public List<resModel> GetResDetails()
        {
            List<resModel> reslist = null;
            reslist = Pe.Reservations.Select(s => new resModel()
            {
                id = s.id,
                Hotel = s.Hotel,
                Arrival = s.Arrival,
                Depature = s.Depature,
                Type = s.Type,
                Guests = s.Guests,
                price = s.price


            }).ToList<resModel>();
            return reslist;
        }

        string resInterface.Insert(resModel id)

        {
            var abc = Pe.Reservations.Where(i => i.id == id.id).FirstOrDefault();
            if (abc == null)
            {
                Pe.Reservations.Add(new Reservation
                {
                    id = id.id,
                    Hotel = id.Hotel,
                    Arrival = id.Arrival,
                    Depature = id.Depature,
                    Type = id.Type,
                    Guests = id.Guests,
                    price = id.price

                });
                Pe.SaveChanges();
                Pe.Dispose();
                return "inserted";
            }
            else
            {
                abc.id = id.id;
                abc.Hotel = id.Hotel;
                abc.Arrival = id.Arrival;
                abc.Depature = id.Depature;
                abc.Type = id.Type;
                abc.Guests = id.Guests;
                abc.price = id.price;
            }
            Pe.SaveChanges();
            Pe.Dispose();
            return "updated";
        }

        string resInterface.Delete(int id)
        {
            var abc = Pe.Reservations.Where(u => u.id == id);
            if (abc != null)
            {
                Pe.Reservations.Remove(abc.FirstOrDefault());
                Pe.SaveChanges();
                return "Succesfully Deleted";
            }
            return "not available";
            
        }

        //string resInterface.updateresinfo(resModel id)
        //{
        //    var abc = Pe.Reservations.Where(u => u.id == id.id).FirstOrDefault();
        //    if (abc != null)
        //    {
        //        abc.id = id.id;
        //        abc.Hotel = id.Hotel;
        //        abc.Arrival = id.Arrival;
        //        abc.Depature = id.Depature;
        //        abc.Type = id.Type;
        //        abc.Guests = id.Guests;
        //        abc.price = id.price;



        //    }
        //    Pe.SaveChanges();
        //    return "updated";
        //}

        public List<Sp_GetAll_Result> sp_getall()
        {
            var abc = Pe.Sp_GetAll().ToList<Sp_GetAll_Result>();
            return abc;
        }
    }






       








}
