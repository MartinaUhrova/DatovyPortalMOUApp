namespace DatovyPortalApp.Models {
    public class DataViewModel {
        public List<Statistics> FilteredValueOutput { get; set; }
        public List<StatisticsCodeList> AvailableStatistics { get; set; }

        public IndicatorCodeList SelectedIndicator { get; set; }

        public List<double> AxisX { get; set; } = new List<double>() { 1, 2, 3, 4 };
        public List<double> AxisY { get; set; } = new List<double>() { 1, 4, 2, 3 };
        public DataViewModel() {
            FilteredValueOutput = new();
            AvailableStatistics = new();
            SelectedIndicator = new();
        }
    }
}
