using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal.BL;
using Personal.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Personal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        IIslider _Context;
        public SliderController(IIslider isld)
        {
            _Context = isld;
        }
        public IActionResult Myslider()
        {
            
            return View(_Context.Getall());
        }
        public IActionResult Edit(int? id  )
        {
            if (id !=null) 
            {

                return View(_Context.Getbyid(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult>  Save(TBslider sllid,List<IFormFile> Files)
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
                        var FilePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploads",Image);
                        //علشان احفظ مسار الصورة ف الداتا بيز
                        using (var stream = System.IO.File.Create(FilePaths)) 
                        {
                            
                            //هياخد نسخة من الصورة اللى اتكريتت
                            //معموله اويت علشان ميخدش نسخة قبل ميعمل كريت
                            await file.CopyToAsync(stream);
                        }
                        //هيضيف الصورة للموديل للحقل بتاعها فى الداتا بيز
                        sllid.Image = Image;
                    }
                }
                
                //لو الحقول اللى جايه فاضية اعمل حفظ 
                //غير كدة اعمل تعديل 
                if (sllid.Id == 0 | sllid.Id == null) 
                {
                    _Context.Add(sllid);
                 return RedirectToAction("Myslider");
                }
                else 
                {
                    //عاوز مش كل اما اعمل ايديت اضطر انى احط صورة 
                    //ف عاوز انه ياخد الصورة القديمة من المديل قبل التعديل 
                    //ويحطها ف الموديل الجديد بعد التعديل 
                    //بس دة بيخلى كل الموديل زى مهو من غير تعديل حتى ف باقى العناصر
                    //بممعنى اصح التعديل مبيتحفظش 
                    //var currentSlider = _Context.Getbyid(Convert.ToInt32(sllid.Id));
                    //string oldimg = currentSlider.Image;
                    //if (Files.Count == 0)
                    //{
                    //    sllid.Image = oldimg;
                    //}

                    _Context.Edit(sllid);

                    return RedirectToAction("Myslider");
                }
            }
            else 
            {
                return View("Myslider");
            }

            
        }

        public IActionResult Delete(int id) 
        {
            //علشان يمسح الصورة من الفولدر
            var currentSlider = _Context.Getbyid(id);
            string oldimg = currentSlider.Image;
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploads", oldimg);

            System.IO.File.Delete(path);
            //علشان يمسح الريكورد
            _Context.Delete(id);


            return RedirectToAction("Myslider");
            
            //_Context.Delete(id);
            //return RedirectToAction("Myslider");
        }

    }
}
