using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal.BL;
using Domain;
using Personal.Models;
namespace Personal.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class ServicesController : Controller
    {
        IIservices _Context;
        public ServicesController(IIservices context)
        {
            _Context = context;
        }
        public IActionResult Myservices()
        {
            return View(_Context.Getall());
        }
        [HttpGet]
        //الاكشن دة للفيو بتاع الحفظ والتعديل
        public IActionResult Save(int? id)
        {

            if (id != null)
            {

                return View(_Context.Getbyid(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }
        }
        

        [HttpPost]
        public IActionResult Save(Tbservice tbservice)
        {
            if (ModelState.IsValid) 
            {
                if (tbservice.Id == 0 | tbservice.Id == null) 
                {
                    _Context.Add(tbservice);
                    return RedirectToAction("Myservices");
                }
                else 
                {
                    _Context.edit(tbservice);
                    return RedirectToAction("Myservices");
                }
                
            }
            else 
            {
            return View("Myservices");
            }
        }
        public IActionResult Delete(int id) 
        {
            _Context.Delete(id);
            return RedirectToAction("Myservices");
        }

    }
}
