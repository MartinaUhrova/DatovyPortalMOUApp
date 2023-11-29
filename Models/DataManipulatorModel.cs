using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DatovyPortalApp.Models {
    public class DataManipulatorModel {

        private readonly DataContext db;

        public DataManipulatorModel(DataContext dbContext) {
            this.db = dbContext;
        }

        public List<SetCodeList>? GetSetCodeList() {
            if (db.SetCodeList == null) return null;
            return db.SetCodeList.ToList();
        }
        public List<DiagnosisCodeList>? GetDiagnosisCodeList() {
            if (db.DiagnosisCodeList == null) return null;
            return db.DiagnosisCodeList.ToList();
        }
        public List<IndicatorCodeList>? GetIndicatorCodeList() {
            if (db.IndicatorCodeList == null) return null;
            return db.IndicatorCodeList.ToList();
        }
        public List<StadiumCodeList>? GetStadiumCodeList() {
            if (db.StadiumCodeList == null) return null;
            return db.StadiumCodeList.ToList();
        }
        public List<PeriodCodeList>? GetPeriodCodeList() {
            if (db.PeriodCodeList == null) return null;
            return db.PeriodCodeList.ToList();
        }
        public List<RegionCodeList>? GetRegionCodeList() {
            if (db.RegionCodeList == null) return null;
            return db.RegionCodeList.ToList();
        }
        public List<StatisticsCodeList>? GetStatisticsCodeList() {
            if (db.StatisticsCodeList == null) return null;
            return db.StatisticsCodeList.ToList();
        }

        public IndicatorCodeList? GetSelectedIndicator(int indicator) {
            return GetIndicatorCodeList()?.
                Where(x => x.Id == indicator).
                FirstOrDefault();
        }

        public List<DiagnosisCodeList> GetSelectedDiagnoses(int indicator) {
            if (db.Statistics == null) return new List<DiagnosisCodeList>();
            return db.Statistics.
                Where(x => x.IndicatorId == indicator).
                Select(x => x.DiagnosisCodeList).
                Distinct().
                OrderBy(x => x).
                ToList();
        }
        public List<StadiumCodeList> GetSelectedStadiums(int indicator) {
            if (db.Statistics == null) return new List<StadiumCodeList>();
            return db.Statistics.
                Where(x => x.IndicatorId == indicator).
                Select(x => x.StadiumCodeList).
                Distinct().
                OrderBy(x => x).
                ToList();
        }
        public List<RegionCodeList> GetSelectedRegions(int indicator) {
            if (db.Statistics == null) return new List<RegionCodeList>();
            return db.Statistics.
                Where(x => x.IndicatorId == indicator).
                Select(x => x.RegionCodeList).
                Distinct().
                OrderBy(x => x).
                ToList();
        }
        public List<PeriodCodeList> GetSelectedPeriods(int indicator) {
            if (db.Statistics == null) return new List<PeriodCodeList>();
            return db.Statistics.
                Where(x => x.IndicatorId == indicator).
                Select(x => x.PeriodCodeList).
                Distinct().
                OrderBy(x => x).
                ToList();
        }

        public DataViewModel GetValueOutput(Statistics viewModel, int indicator) {
            DataViewModel dataViewModel = new();
            if (db.Statistics == null) {
                dataViewModel.FilteredValueOutput = new List<Statistics>();
                dataViewModel.AvailableStatistics = new List<StatisticsCodeList>();
            }
            else {
                dataViewModel.FilteredValueOutput = db.Statistics.
                    Where(x => x.IndicatorId == indicator).
                    Where(x => x.DiagnosisId == viewModel.DiagnosisId).
                    Where(x => x.StadiumId == viewModel.StadiumId).
                    Where(x => x.RegionId == viewModel.RegionId).
                    Where(x => x.PeriodId == viewModel.PeriodId).
                    OrderBy(x => x.StatisticsId).
                    ToList();

                List<int> SelectedIds = dataViewModel.FilteredValueOutput.Select(x => x.StatisticsId).ToList();              
                dataViewModel.AvailableStatistics = db.Statistics.
                    Select(x => x.StatisticsCodeList).
                    Where(x => SelectedIds.Contains(x.Id)).
                    Distinct().
                    OrderBy(x => x.Id).
                    ToList();
            }
            IndicatorCodeList? selectedIndicator = GetSelectedIndicator(indicator);
            if (selectedIndicator == null) dataViewModel.SelectedIndicator = new IndicatorCodeList();
            else {
                dataViewModel.SelectedIndicator = selectedIndicator;
            }
            return dataViewModel;


        }
    }
}
