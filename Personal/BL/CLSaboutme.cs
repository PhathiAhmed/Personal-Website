using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal.Models;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Personal.BL
{
    public interface IIaboutme 
    {
        List<Tbaboutme> Getall();
        bool Add(Tbaboutme aboutme);
        Tbaboutme Getbyid(int id);
        bool Edit(Tbaboutme tbaboutme);
        bool Delete(int id);
    }
    public class CLSaboutme:IIaboutme
    {

        personaldpContext _Context;
        public CLSaboutme(personaldpContext context)
        {
            _Context = context;
        }
        public List<Tbaboutme> Getall() 
        {
            List<Tbaboutme> aboutme = _Context.Tbaboutmes.OrderByDescending(a => a.Name).ToList();
            _Context.SaveChanges();
            return aboutme;
        }

        public Tbaboutme Getbyid( int id ) 
        {
            Tbaboutme tbaboutme = _Context.Tbaboutmes.FirstOrDefault(a => a.Id == id);
            return tbaboutme;
        }

        public bool Add(Tbaboutme aboutme)

        {
            try
            {
                _Context.Add<Tbaboutme>(aboutme);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            

        }

        public bool Edit(Tbaboutme tbaboutme) 
        {
            try
            {
                _Context.Entry(tbaboutme).State = EntityState.Modified;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                Tbaboutme  tbaboutme = _Context.Tbaboutmes.Where(a => a.Id == id).FirstOrDefault();
                _Context.Tbaboutmes.Remove(tbaboutme);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }
    }
}
