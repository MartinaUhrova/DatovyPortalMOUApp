using Microsoft.EntityFrameworkCore;

namespace DatovyPortalApp.Models {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions options) : base(options) {
        }
        public DbSet<SetCodeList>? SetCodeList { get; set; }
        public DbSet<IndicatorCodeList>? IndicatorCodeList { get; set; }
        public DbSet<PeriodCodeList>? PeriodCodeList { get; set; }
        public DbSet<RegionCodeList>? RegionCodeList { get; set; }
        public DbSet<StadiumCodeList>? StadiumCodeList { get; set; }
        public DbSet<DiagnosisCodeList>? DiagnosisCodeList { get; set; }
        public DbSet<StatisticsCodeList>? StatisticsCodeList { get; set; }
        public DbSet<Statistics>? Statistics { get; set; }

    }
}
