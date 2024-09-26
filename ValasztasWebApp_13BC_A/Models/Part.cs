using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValasztasWebApp_13BC_A.Models
{
	public class Part
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string RovidNev { get; set; }
        public string? TeljesNev { get; set; }
        public ICollection<Jelolt> Jeloltek {  get; set; }
    }
}
