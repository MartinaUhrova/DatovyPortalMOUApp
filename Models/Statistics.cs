using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DatovyPortalApp.Models {
    public class Statistics {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int SetId { get; set; }
        [Required]
        public int IndicatorId { get; set; }
        [Required]
        [Display(Name = "Vyberte diagnózu: ")]
        public int DiagnosisId {  get; set; }
        [Required]
        [Display(Name = "Vyberte stadium: ")]
        public int StadiumId {  get; set; }
        [Required]
        [Display(Name = "Vyberte bydliště: ")]
        public int RegionId { get; set; }
        [Required]
        [Display(Name = "Vyberte období: ")]
        public int PeriodId {  get; set; }
        [Required]
        public int StatisticsId { get; set; }
        [AllowNull]
        public int? SampleSize {  get; set; }
        [AllowNull]
        public double Value { get; set; }
        [AllowNull]
        public double? LowerLimit {  get; set; }
        [AllowNull]
        public double? UpperLimit { get; set;}

        public SetCodeList SetCodeList { get; set; } = null!;
        public IndicatorCodeList IndicatorCodeList { get; set; } = null!;
        public DiagnosisCodeList DiagnosisCodeList { get; set; } = null!;
        public StadiumCodeList StadiumCodeList { get; set; } = null!;
        public RegionCodeList RegionCodeList { get; set; } = null!;
        public PeriodCodeList PeriodCodeList { get; set; } = null!;
        public StatisticsCodeList StatisticsCodeList { get; set; } = null!;
    }
}
