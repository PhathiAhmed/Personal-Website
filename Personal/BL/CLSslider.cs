using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Personal.Models;
namespace Personal.BL
{
    public interface IIslider 
    {
        List<TBslider> Getall();
        TBslider Getbyid(int id);
        bool Add(TBslider sllid);
        bool Edit(TBslider sslid);
        bool Delete(int id);
    }
    public class CLSslider:IIslider
    {
        personaldpContext _Context;
        public CLSslider(personaldpContext context)
        {
            _Context = context;
        }
       
        public List<TBslider> Getall()
        {
            
            List<TBslider> Myslider = _Context.Tbsliders.OrderByDescending(a => a.Id).ToList();
            _Context.SaveChanges();
            return Myslider;
        }

        public TBslider Getbyid(int id) 
        {
            TBslider sslid = _Context.Tbsliders.FirstOrDefault(a => a.Id == id);
            return sslid;
        }
        
        public bool Add(TBslider sllid) 

        {
            try
            {
                _Context.Add<TBslider>(sllid);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool Edit(TBslider sslid) 
        {
            try 
            {

                _Context.Entry(sslid).State = EntityState.Modified;

                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        
        }

        public bool Delete (int id)
        {
            try
            {
                  TBslider dslider = _Context.Tbsliders.Where(a => a.Id == id).FirstOrDefault();
                _Context.Tbsliders.Remove(dslider);
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
