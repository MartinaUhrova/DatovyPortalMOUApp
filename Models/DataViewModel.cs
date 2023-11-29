namespace DatovyPortalApp.Models {
    public class DataViewModel {
        public List<Statistics> FilteredValueOutput { get; set; }
        public List<StatisticsCodeList> AvailableStatistics { get; set; }

        public IndicatorCodeList SelectedIndicator {  get; set; }
        public DataViewModel() {
            FilteredValueOutput = new();
            AvailableStatistics = new();
            SelectedIndicator = new();
        }
    }
}
