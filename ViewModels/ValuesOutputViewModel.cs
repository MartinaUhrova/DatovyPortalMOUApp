using DatovyPortalApp.Models;

namespace DatovyPortalApp.ViewModels
{
    public class ValuesOutputViewModel
    {
        public List<Statistics> FilteredValueOutput { get; set; }
        public List<StatisticsCodeList> AvailableStatistics { get; set; }
        public IndicatorCodeList SelectedIndicator { get; set; }
        
        public ValuesOutputViewModel()
        {
            FilteredValueOutput = new();
            AvailableStatistics = new();
            SelectedIndicator = new();
        }
    }
}
