using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatovyPortalApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatovyPortal.Controllers {


    public class DataController : Controller {
        private readonly DataContext context;
        private readonly DataManipulatorModel controller;       

        public DataController(DataContext context) {
            this.context = context;
            controller = new(context);         
        }

        [Route("/Data/Index/{indicator:int=1}")]
        public IActionResult Index(int indicator = 1) {          
            ViewBag.Sets = controller.GetSetCodeList();
            ViewBag.Indicators = controller.GetIndicatorCodeList();
            ViewBag.SelectedIndicator = controller.GetSelectedIndicator(indicator);
            ViewBag.SelectedDiagnoses = controller.GetSelectedDiagnoses(indicator);
            ViewBag.SelectedStadiums = controller.GetSelectedStadiums(indicator);
            ViewBag.SelectedRegions = controller.GetSelectedRegions(indicator);
            ViewBag.SelectedPeriods = controller.GetSelectedPeriods(indicator);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ValuesOutput(Statistics viewModel, int indicator) {
            Console.WriteLine("Indikator:" + indicator);
            DataViewModel dataViewModel = controller.GetValueOutput(viewModel, indicator);
            
            return PartialView("_ValuesOutput", dataViewModel);
        }

        //[HttpPost]
        //public IActionResult ValuesOutput(Statistics statistics) {
        //    int regionId = statistics.RegionId;            
        //    Console.WriteLine("Byla vybrana moznost: "+ regionId);
        //    //DbManipulatorModel dbManipulatorModel = new(_context);
        //    //var x = (from e in _context.DataModel
        //    //         where e.KrajBydliste == dataModel.KrajBydliste
        //    //         select e.Hodnota).ToList();
        //    //var y = (from e in _context.DataModel
        //    //         where e.KrajBydliste == dataModel.KrajBydliste
        //    //         select e.Hodnota).ToList();
        //    //ViewBag.AxisX = x;
        //    //ViewBag.AxisY = y;
        //    return RedirectToAction("Index", statistics);
        //}

        //public IActionResult GetSelectedIndicator(int indicator = 1) {
        //    DbManipulatorModel controller = new(context);
        //    ViewBag.Stadiums = controller.GetStadiumCodeList();
        //    return RedirectToAction(nameof(Index));
        //}


    }
}
