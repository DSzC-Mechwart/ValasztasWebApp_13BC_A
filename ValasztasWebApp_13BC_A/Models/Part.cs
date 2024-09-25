using System.ComponentModel.DataAnnotations;

namespace ValasztasWebApp_13BC_A.Models
{
	public class Part
	{
        [Key]
        public string RovidNev { get; set; }
        public string? TeljesNev { get; set; }
        public ICollection<Jelolt> Jeloltek {  get; set; }
    }
}
