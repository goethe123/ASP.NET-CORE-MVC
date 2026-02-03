using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyFlow.Context;
using MoneyFlow.Managers;
using MoneyFlow.Models;
using System.Collections.Generic;

namespace MoneyFlow.Controllers
{
    public class ServiceController(ServicesManager _serviceManager): Controller
    {
        public IActionResult Index()
        {
            var list = _serviceManager.GetAll(1);
            return View(list);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult New(ServiceVM model)
        {
            if (!ModelState.IsValid) return View(model);
            model.UserId = 1;

            var response=_serviceManager.New(model);
            if (response == 1) return RedirectToAction("Index");

            ViewBag.message = "Error";
            return View();
        }
    }
}
