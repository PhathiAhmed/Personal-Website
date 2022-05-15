using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal.Models;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Personal.BL
{
    public interface IIservices 
    {
        List<Tbservice> Getall();
        bool Add(Tbservice tbservice);
        Tbservice Getbyid(int id);
        bool edit(Tbservice tbservice);
        bool Delete(int id);
    }
    public class CLSservices:IIservices
    {
        personaldpContext _Context;
        public CLSservices(personaldpContext context)
        {
            _Context = context;
        }

        public List<Tbservice> Getall() 
        {
            List<Tbservice> services = _Context.Tbservices.OrderBy(a => a.Id).ToList();
            return services;
        
        }
        public bool Add(Tbservice tbservice) 
        {
            try
            {
                _Context.Add<Tbservice>(tbservice);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        public Tbservice Getbyid(int id) 
        {
            Tbservice tbservice = _Context.Tbservices.FirstOrDefault(a => a.Id == id);
            return tbservice;
        }
        public bool edit(Tbservice tbservice) 
        {
            try
            {
                _Context.Entry(tbservice).State = EntityState.Modified;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
        public bool Delete(int id) 
        {
            try
            {
                Tbservice tbservice = _Context.Tbservices.Where(a => a.Id == id).FirstOrDefault();
                _Context.Tbservices.Remove(tbservice);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

    }
}
