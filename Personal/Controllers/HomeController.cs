using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Personal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Personal.BL;
using Personal.Models;
namespace Personal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IIslider _conty;
        IIaboutme _contx;
        IIservices _contz;
        IIwork _contc;
        IIcontect _contb;
        public HomeController(ILogger<HomeController> logger,
            IIslider conty,
            IIaboutme contx,
            IIservices contz,
            IIwork contc,
            IIcontect contb
            )
        {
            _logger = logger;
             _conty=conty;
            _contx = contx;
            _contz = contz;
            _contc = contc;
            _contb = contb;
        }

        public IActionResult Index()
        {
            //(Take(1))هات اخر واحد
            Viewmodel viewmodel = new Viewmodel();
            viewmodel.sliderinfo = _conty.Getall();
            viewmodel.sliderinfo = viewmodel.sliderinfo.Take(1);
            viewmodel.aboutme = _contx.Getall();
            viewmodel.aboutme = viewmodel.aboutme.Take(1);
            viewmodel.service = _contz.Getall();
            viewmodel.work = _contc.Getall();
            viewmodel.contect = _contb.Getall();
            viewmodel.aboutme = viewmodel.aboutme.Take(1);


            return View(viewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
