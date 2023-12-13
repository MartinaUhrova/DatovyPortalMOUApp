using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatovyPortalApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DatovyPortalApp.Services;
using DatovyPortalApp.ViewModels;

namespace DatovyPortal.Controllers {


    public class DataController : Controller {
        private readonly DataService service;

        public DataController(DataService dataService) {
            this.service = dataService;
        }

        [Route("/Data/Index/{indicator:int=1}")]
        public async Task<IActionResult> Index(int indicator = 1) {

            var selectedIndicator = await service.GetSelectedIndicatorAsync(indicator);
            if (selectedIndicator == null) {
                return View("NotFound");
            }
            ViewBag.SelectedIndicator = selectedIndicator;
            ViewBag.Sets = await service.GetSetCodeListAsync();
            ViewBag.Indicators = await service.GetIndicatorCodeListAsync(); ;
            ViewBag.SelectedDiagnoses = await service.GetSelectedDiagnosesAsync(indicator);
            ViewBag.SelectedStadiums = await service.GetSelectedStadiumsAsync(indicator);
            ViewBag.SelectedRegions = await service.GetSelectedRegionsAsync(indicator);
            ViewBag.SelectedPeriods = await service.GetSelectedPeriodsAsync(indicator);
            ViewBag.SelectedStatistics = await service.GetSelectedStatisticsAsync(indicator);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValuesOutput(DataToOutputViewModel inputViewModel, int indicator) {
            ValuesOutputViewModel outputViewModel = await service.GetValuesOutputAsync(inputViewModel, indicator);

            return PartialView("_ValuesOutput", outputViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GraphOutput(DataToOutputViewModel inputViewModel, int indicator) {
            await Console.Out.WriteLineAsync(inputViewModel.DiagnosisIdGraphOutput.ToString());
            GraphOutputViewModel graphViewModel = await service.GetGraphOutputAsync(inputViewModel, indicator);

            return PartialView("_GraphOutput", graphViewModel);
        }
    }
}
