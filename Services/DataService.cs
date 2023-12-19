using DatovyPortalApp.Models;
using DatovyPortalApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Xml;

namespace DatovyPortalApp.Services {
    public class DataService {

        private readonly ApplicationDbContext dbContext;

        public DataService(ApplicationDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<SetCodeList>?> GetSetCodeListAsync() {
            if (dbContext.SetCodeList == null) return null;
            return await dbContext.SetCodeList.ToListAsync();
        }
        public async Task<IEnumerable<DiagnosisCodeList>?> GetDiagnosisCodeListAsync() {
            if (dbContext.DiagnosisCodeList == null) return null;
            return await dbContext.DiagnosisCodeList.ToListAsync();
        }
        public async Task<IEnumerable<IndicatorCodeList>?> GetIndicatorCodeListAsync() {
            if (dbContext.IndicatorCodeList == null) return null;
            return await dbContext.IndicatorCodeList.ToListAsync();
        }
        public async Task<IEnumerable<StadiumCodeList>?> GetStadiumCodeListAsync() {
            if (dbContext.StadiumCodeList == null) return null;
            return await dbContext.StadiumCodeList.ToListAsync();
        }
        public async Task<IEnumerable<PeriodCodeList>?> GetPeriodCodeListAsync() {
            if (dbContext.PeriodCodeList == null) return null;
            return await dbContext.PeriodCodeList.ToListAsync();
        }
        public async Task<IEnumerable<RegionCodeList>?> GetRegionCodeListAsync() {
            if (dbContext.RegionCodeList == null) return null;
            return await dbContext.RegionCodeList.ToListAsync();
        }
        public async Task<IEnumerable<StatisticsCodeList>?> GetStatisticsCodeListAsync() {
            if (dbContext.StatisticsCodeList == null) return null;
            return await dbContext.StatisticsCodeList.ToListAsync();
        }

        public async Task<IndicatorCodeList?> GetSelectedIndicatorAsync(int indicator) {
            return (await GetIndicatorCodeListAsync())?.
                FirstOrDefault(x => x.Id == indicator);
        }

        public async Task<IEnumerable<DiagnosisCodeList>> GetSelectedDiagnosesAsync(int indicator) {
            if (dbContext.Statistics == null) return new List<DiagnosisCodeList>();
            return await dbContext.Statistics.
                Where(x => x.IndicatorId == indicator).
                Select(x => x.DiagnosisCodeList).
                Distinct().
                OrderBy(x => x).
                ToListAsync();
        }
        public async Task<IEnumerable<StadiumCodeList>> GetSelectedStadiumsAsync(int indicator) {
            if (dbContext.Statistics == null) return new List<StadiumCodeList>();
            return await dbContext.Statistics.
                Where(x => x.IndicatorId == indicator).
                Select(x => x.StadiumCodeList).
                Distinct().
                OrderBy(x => x).
                ToListAsync();
        }
        public async Task<IEnumerable<RegionCodeList>> GetSelectedRegionsAsync(int indicator) {
            if (dbContext.Statistics == null) return new List<RegionCodeList>();
            return await dbContext.Statistics.
                Where(x => x.IndicatorId == indicator).
                Select(x => x.RegionCodeList).
                Distinct().
                OrderBy(x => x).
                ToListAsync();
        }
        public async Task<IEnumerable<PeriodCodeList>> GetSelectedPeriodsAsync(int indicator) {
            if (dbContext.Statistics == null) return new List<PeriodCodeList>();
            return await dbContext.Statistics.
                Where(x => x.IndicatorId == indicator).
                Select(x => x.PeriodCodeList).
                Distinct().
                OrderBy(x => x).
                ToListAsync();
        }

        public async Task<IEnumerable<StatisticsCodeList>> GetSelectedStatisticsAsync(int indicator) {
            if (dbContext.Statistics == null) return new List<StatisticsCodeList>();
            return await dbContext.Statistics.
                Where(x => x.IndicatorId == indicator).
                Select(x => x.StatisticsCodeList).
                Distinct().
                OrderBy(x => x).
                ToListAsync();
        }

        public async Task<ValuesOutputViewModel> GetValuesOutputAsync(DataToOutputViewModel viewModel, int indicator) {
            ValuesOutputViewModel valuesOutputVM = new();
            if (dbContext.Statistics == null) {
                valuesOutputVM.FilteredValueOutput = new List<Statistics>();
                valuesOutputVM.AvailableStatistics = new List<StatisticsCodeList>();
            }
            else {
                valuesOutputVM.FilteredValueOutput = await dbContext.Statistics.
                    Where(x => x.IndicatorId == indicator).
                    Where(x => x.DiagnosisId == viewModel.DiagnosisIdValueOutput).
                    Where(x => x.StadiumId == viewModel.StadiumIdValueOutput).
                    Where(x => x.RegionId == viewModel.RegionIdValueOutput).
                    Where(x => x.PeriodId == viewModel.PeriodIdValueOutput).
                    OrderBy(x => x.StatisticsId).
                    ToListAsync();

                List<int> SelectedIds = valuesOutputVM.FilteredValueOutput.Select(x => x.StatisticsId).ToList();
                valuesOutputVM.AvailableStatistics = await dbContext.Statistics.
                    Select(x => x.StatisticsCodeList).
                    Where(x => SelectedIds.Contains(x.Id)).
                    Distinct().
                    OrderBy(x => x.Id).
                    ToListAsync();
            }
            IndicatorCodeList? selectedIndicator = await GetSelectedIndicatorAsync(indicator);
            if (selectedIndicator == null) valuesOutputVM.SelectedIndicator = new IndicatorCodeList();
            else {
                valuesOutputVM.SelectedIndicator = selectedIndicator;
            }
            return valuesOutputVM;
        }

        public async Task<GraphOutputViewModel> GetGraphOutputAsync(DataToOutputViewModel viewModel, int indicator) {
            if (dbContext.Statistics is null) return new GraphOutputViewModel();
            GraphOutputViewModel graphOutputVM = new();
            List<string> axisX = new();
            List<double> axisY = new();

            if (viewModel.StratificationGraphOutput == 4) {
                List<PeriodCodeList> filteredPeriods = new();
                filteredPeriods = GetSelectedPeriodsAsync(indicator).Result.
                    Where((value, index) => viewModel.PeriodIdChecksGraphOutput[index]).
                    ToList();
                axisX = filteredPeriods.Select(x => x.Name).ToList();
                axisY = await dbContext.Statistics.
                    Where(x => x.IndicatorId == indicator).
                    Where(x => x.StadiumId == viewModel.StadiumIdGraphOutput).
                    Where(x => x.RegionId == viewModel.RegionIdGraphOutput).
                    Where(x => x.DiagnosisId == viewModel.DiagnosisIdGraphOutput).
                    Where(x => x.StatisticsId == viewModel.StatisticsIdGraphOutput).
                    Where(x => filteredPeriods.Select(per => per.Id).Contains(x.PeriodId)).
                    OrderBy(x => x.PeriodId).
                    Select(x => x.Value).
                    ToListAsync();
                graphOutputVM.AxisXLabel = "Období";
            }

            graphOutputVM.ConfidenceInterval = viewModel.StatisticsIdGraphOutput <= 3;            
            graphOutputVM.AxisX = JsonSerializer.Serialize(axisX);            
            graphOutputVM.AxisY = JsonSerializer.Serialize(axisY);

            return graphOutputVM;
        }
    }
}
