﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValasztasWebApp_13BC_A.Models
{
	public class Part
	{
        [Key]
        public string RovidNev { get; set; }
        public string? TeljesNev { get; set; }
        public virtual ICollection<Jelolt> Jeloltek {  get; set; }
    }
}
