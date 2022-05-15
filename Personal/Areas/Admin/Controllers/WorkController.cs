using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal.BL;
using Personal.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Personal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {
        IIwork _Context;
        public WorkController(IIwork context)
        {
            _Context = context;
        }
        public IActionResult Mywork()
        {
            return View(_Context.Getall());
        }
        [HttpGet]
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
        public async Task<IActionResult>  Save(Tbmywork tbmywork, List<IFormFile> Files)
        {
            
            if (ModelState.IsValid) 
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {

                        //علشان لو جيت احفظ صورة جديدة بس فيه صورة بنفس الاسم ف قاعدة البيانات
                        //تتحل عن طريق الجويد دة بيدى لكل مدخل داخل الدتابيز رقم تعريفى مختلف
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        //علشان اجيب مسار الصورة 
                        var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploadswork", Image);
                        //علشان احفظ مسار الصورة ف الداتا بيز
                        using (var stream = System.IO.File.Create(FilePaths))
                        {

                            //هياخد نسخة من الصورة اللى اتكريتت
                            //معموله اويت علشان ميخدش نسخة قبل ميعمل كريت
                            await file.CopyToAsync(stream);
                        }
                        //هيضيف الصورة للموديل للحقل بتاعها فى الداتا بيز
                        tbmywork.WorkImage = Image;
                    }
                    if (tbmywork.Id==0|tbmywork.Id==null) 
                    {
                        _Context.Add(tbmywork);
                        return RedirectToAction("Mywork");
                    }
                    else 
                    {

                        _Context.Edit(tbmywork);
                        return RedirectToAction("Mywork");
                    }

                    
                }
            }
            
            return View("Mywork");
        }
        public  IActionResult Delete(int id) 
        {
            //علشان يمسح الصورة من الفولدر
            var currentWork = _Context.Getbyid(id);
            string oldimg = currentWork.WorkImage;
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploadswork", oldimg);

            System.IO.File.Delete(path);
            //علشان يمسح الريكورد
            _Context.Delete(id);
            return RedirectToAction("Mywork");
        
        }

    }
}
