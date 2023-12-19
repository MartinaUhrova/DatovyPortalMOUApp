using DatovyPortalApp.Models;
using System.ComponentModel.DataAnnotations;

namespace DatovyPortalApp.ViewModels {
    public class DataToOutputViewModel {
        [Display(Name = "Vyberte diagnózu: ")]
        public int DiagnosisIdValueOutput { get; set; }
        [Display(Name = "Vyberte stadium: ")]
        public int StadiumIdValueOutput {  get; set; }
        [Display(Name = "Vyberte bydliště: ")]
        public int RegionIdValueOutput { get; set; }
        [Display(Name = "Vyberte období: ")]
        public int PeriodIdValueOutput { get; set; }
        [Display(Name = "Stratifikace: ")]
        public int StratificationGraphOutput {  get; set; }
        public int DiagnosisIdGraphOutput { get; set; }
        public int StadiumIdGraphOutput { get; set; }
        
        public int RegionIdGraphOutput { get; set; }
        
        public int PeriodIdGraphOutput { get; set; }

        public int StatisticsIdGraphOutput { get; set; }

        public List<bool> DiagnosisIdChecksGraphOutput { get; set; }=new List<bool>();
        public List<bool> StadiumIdChecksGraphOutput { get; set; } = new List<bool>();
        public List<bool> RegionIdChecksGraphOutput { get; set; } = new List<bool>();
        public List<bool> PeriodIdChecksGraphOutput { get; set; } = new List<bool>();


    }
}
