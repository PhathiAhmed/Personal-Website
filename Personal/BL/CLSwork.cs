using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal.Models;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Personal.BL
{
    public interface IIwork 
    {
        List<Tbmywork> Getall();
        Tbmywork Getbyid(int id);
        bool Add(Tbmywork tbmywork);
        bool Edit(Tbmywork tbmywork);
        bool Delete(int id);


    }
    public class CLSwork:IIwork
    {
        personaldpContext _Context;
        public CLSwork(personaldpContext context)
        {
            _Context = context;
        }

        public List<Tbmywork> Getall() 
        {
            List<Tbmywork> tbmyworks = _Context.Tbmyworks.OrderBy(a => a.Id).ToList();
            _Context.SaveChanges();
            return tbmyworks;
        }
        public Tbmywork Getbyid(int id) 
        {
            Tbmywork tbmywork = _Context.Tbmyworks.Where(a => a.Id == id).FirstOrDefault();
            return tbmywork;
            
        }
        public bool Add(Tbmywork tbmywork)
        {
            try
            {
                _Context.Add<Tbmywork>(tbmywork);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }
        public bool Edit(Tbmywork tbmywork) 
        {
            try
            {
                _Context.Entry(tbmywork).State = EntityState.Modified;
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
                Tbmywork tbmywork = _Context.Tbmyworks.Where(a => a.Id == id).FirstOrDefault();
                _Context.Tbmyworks.Remove(tbmywork);
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
