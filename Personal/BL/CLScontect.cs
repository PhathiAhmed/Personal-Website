using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal.Models;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Personal.BL
{
    public interface IIcontect 
    {
        List<Tbcontect> Getall();
        Tbcontect Getbyid(int id);
        bool Add(Tbcontect tbcontect);
        bool Edit(Tbcontect tbcontect);
        bool Delete(int id);
    }
    public class CLScontect:IIcontect
    {
        personaldpContext _Context;
        public CLScontect(personaldpContext context)
        {
            _Context = context;
        }
        public List<Tbcontect> Getall() 
        {
            List<Tbcontect> tbcontects = _Context.Tbcontects.OrderByDescending(a => a.Id).ToList();
            _Context.SaveChanges();
            return tbcontects;
        }
        public Tbcontect Getbyid(int id) 
        {
            Tbcontect tbcontect  = _Context.Tbcontects.Where(a => a.Id == id).FirstOrDefault();
            return tbcontect;
        }
        public bool Add(Tbcontect tbcontect)
        {
            try
            {
                _Context.Add<Tbcontect>(tbcontect);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        
        }
        public bool Edit(Tbcontect tbcontect) 
        {
            try
            {
                _Context.Entry(tbcontect).State = EntityState.Modified;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false ;
            }
        }
        public bool Delete(int id) 
        {
            try
            {
                Tbcontect tbcontect = _Context.Tbcontects.Where(a => a.Id == id).FirstOrDefault();
                _Context.Tbcontects.Remove(tbcontect);
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
