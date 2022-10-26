using BigHomeWorkFromWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BigHomeWorkFromWeb.Controllers
{
    public class AdressController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<AdressModel> adress;


            adress = await AdressHelper.GetAdress();
            return View(adress);

        }
        public async Task<AdressModel> GetAdress(int? id)
        {
            List<AdressModel> adress;
            AdressModel adressModel;

            adress = await AdressHelper.GetAdress();
            adressModel = adress.First(a => a.Id == id);
            return adressModel;
        }

        [HttpGet]
        public IActionResult AddAdress()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdress(AdressModel adressModel)
        {
            await AdressHelper.AddAdress(adressModel);

            return RedirectToAction("Index", "Home"); ;
        }
    }
}
