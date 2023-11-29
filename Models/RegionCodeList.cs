using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatovyPortalApp.Models {
    public class RegionCodeList {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";
        [ForeignKey("RegionId")]
        public List<Statistics> Statistics { get; } = new List<Statistics>();
    }
}
