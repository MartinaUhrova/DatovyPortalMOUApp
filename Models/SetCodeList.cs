using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatovyPortalApp.Models {
    public class SetCodeList {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [ForeignKey("SetId")]
        public List<Statistics> Statistics { get; } = new List<Statistics>();

    }
}
