using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Xml.Linq;
using webapi1.Models;

namespace webapi1.rep
{
    public interface Empinterface
    {
        List<EmpModel> GetEmpDetails();
        string Delete(int id);

       string updateempinfo(EmpModel id);
       string Insert(EmpModel id);
       string Bulkinsert(List<EmpModel> em);
        
        Emp1 GetByIdDetails(int id);
        //string Bulkdelete(List<EmpModel> em);
    }

    class EmpDetails : Empinterface
    {
        PottiEntities sb = new PottiEntities();
        public List<Emp1> emplist = new List<Emp1>() { };


        List<EmpModel> Empinterface.GetEmpDetails()
        {
            List<EmpModel> EmpList = null;
            EmpList = sb.Emp1.Select(s => new EmpModel()
            {
                Name = s.Name,
                id = s.id,
                age = s.age,
                phonenumber = s.phonenumber,
                city = s.city,
                Address = s.Address,
                Country = s.Country


            }).ToList<EmpModel>();
            return EmpList;
        }

        string Empinterface.Delete(int id)
        {
            var abc = sb.Emp1.Where(u => u.id == id).FirstOrDefault();
            if (abc != null)
            {
                sb.Emp1.Remove(abc);
            }
            sb.SaveChanges();
            return "Succesfully Deleted";
        }

        string Empinterface.Insert(EmpModel id)

        {
            var abc = sb.Emp1.Where(i => i.id == id.id).FirstOrDefault();
            if (abc == null)
            {
                sb.Emp1.Add(new Emp1
                {
                    Name = id.Name,
                    age = id.age,
                    id = id.id,
                    phonenumber = id.phonenumber,
                    city = id.city,
                    Address = id.Address,
                    Country = id.Country,

                });
            }
            sb.SaveChanges();
            return "inserted";
        }


        public string updateempinfo(EmpModel id)
        {
            var abc = sb.Emp1.Where(sb => sb.id == id.id).FirstOrDefault();
            if (abc != null)
            {
                abc.Name = id.Name;
                abc.age = id.age;
                abc.id = id.id;
                abc.phonenumber = id.phonenumber;
                abc.city = id.city;
                abc.Address = id.Address;
                abc.Country = id.Country;

                sb.SaveChanges();
                sb.Dispose();

            }

            return "updated";
        }

        string Empinterface.Bulkinsert(List<EmpModel> em)
        {
            foreach (EmpModel ins in em)
            {
                var abc = sb.Emp1.Where(i => i.id == ins.id).FirstOrDefault();
                if (abc == null)
                {
                    sb.Emp1.Add(new Emp1
                    {
                        Name = ins.Name,
                        age = ins.age,
                        id = ins.id,
                        phonenumber = ins.phonenumber,
                        city = ins.city,
                        Address = ins.Address,
                        Country = ins.Country,
                    });
                    sb.SaveChanges();


                }

            }
            return "Bulk inserted";



        }


        //public string Bulkdelete(List<EmpModel>em)
        //{
        //    foreach(var del in sb.Emp1)
        //    {
        //        sb.Emp1.Remove(del);
        //    }
        //    sb.SaveChanges();
        //    return "Bulk deleted";
        //}


        //public EmpModel GetByIdDetails(int id)
        Emp1 Empinterface.GetByIdDetails(int id)
        {
           
            var abc  = sb.Emp1.FirstOrDefault(e => e.id == id);
            return abc;

        }

       
    }




}


        

  