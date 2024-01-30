using DatovyPortalApp.Models;

namespace DatovyPortalApp.ViewModels {
    public class GraphOutputViewModel {

        public string AxisX { get; set; } = "";
        public string AxisY { get; set; } = "";
        public string AxisXLabel { get; set; } = "";

        public string Title { get; set; } = "";
        public bool ConfidenceInterval {  get; set; } = false;
    }
}
