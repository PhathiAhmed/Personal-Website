using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal.BL;
using Personal.Models;

namespace Personal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContectController : Controller
    {
        IIcontect _Context;
        public ContectController(IIcontect context)
        {
            _Context = context;

        }
        public IActionResult Mycontect()
        {
            return View(_Context.Getall());
        }

        [HttpGet]
        public IActionResult Save(int? id)
        {
            if(id != null) 
            {
                return View(_Context.Getbyid(Convert.ToInt32(id)));
            }
            else 
            {
                return View();

            }
        }
        [HttpPost]
        public IActionResult Save(Tbcontect tbcontect)
        {
            if (ModelState.IsValid) 
            {
                if (tbcontect.Id == 0 | tbcontect.Id == null) 
                {
                    _Context.Add(tbcontect);
                    return RedirectToAction("Mycontect");
                }
                else 
                {
                    _Context.Edit(tbcontect);
                    return RedirectToAction("Mycontect");
                }
            }
            return View("Mycontect");

        }
        public IActionResult Delete(int id) 
        {
            _Context.Delete(id);
            return RedirectToAction("Mycontect");
        }
    }
}
