using DatovyPortalApp.Models;

namespace DatovyPortalApp.ViewModels {
    public class GraphOutputViewModel {

        public List<double> AxisX { get; set; } = new List<double>() { 1, 2, 3, 4 };
        public List<double> AxisY { get; set; } = new List<double>() { 1, 4, 2, 3 };
        public GraphOutputViewModel() {

        }
    }
}
