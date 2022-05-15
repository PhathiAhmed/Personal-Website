using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal.BL;
using Domain;
using Personal.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Personal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        IIaboutme _iaboutme;
        public AboutController(IIaboutme iaboutme)
        {
            _iaboutme = iaboutme;
        }
        public IActionResult About()
        {

            return View(_iaboutme.Getall());
        }

        public IActionResult Edit(int? id)
        {

            if (id != null)
            {

                return View(_iaboutme.Getbyid(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult>  Save(Tbaboutme aboutme, List<IFormFile> Files)
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
                        var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploadsabout", Image);
                        //علشان احفظ مسار الصورة ف الداتا بيز
                        using (var stream = System.IO.File.Create(FilePaths))
                        {

                            //هياخد نسخة من الصورة اللى اتكريتت
                            //معموله اويت علشان ميخدش نسخة قبل ميعمل كريت
                            await file.CopyToAsync(stream);
                        }
                        //هيضيف الصورة للموديل للحقل بتاعها فى الداتا بيز
                        aboutme.Image = Image;
                    }
                }
                if (aboutme.Id == 0 | aboutme.Id == null)
                {
                    _iaboutme.Add(aboutme);
                    return RedirectToAction("About");
                }
                else
                {
                    _iaboutme.Edit(aboutme);
                    return RedirectToAction("About");
                }
            }
            else 
            {
                return View("About");

            }

        }

        public IActionResult Delete(int id)
        {
            //علشان يمسح الصورة من الفولدر
            var currentSlider = _iaboutme.Getbyid(id);
            string oldimg = currentSlider.Image;
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploadsabout", oldimg);

            System.IO.File.Delete(path);
            //علشان يمسح الريكورد
            _iaboutme.Delete(id);
            return RedirectToAction("About");
        }
    }
}
