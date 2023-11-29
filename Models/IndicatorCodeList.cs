using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatovyPortalApp.Models {
    public class IndicatorCodeList {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public int IdSet { get; set; }
        [Required]
        public string Description { get; set; } = "";

        [ForeignKey("IndicatorId")]
        public List<Statistics> Statistics { get; } = new List<Statistics>();
    }
}
