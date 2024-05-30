using System;
using System.ComponentModel.DataAnnotations;

namespace BpkbApi.Models
{
	public class MsStorageLocation
	{
        [Key]
        [StringLength(10)]
        public string LocationId { get; set; }

        [StringLength(100)]
        public string LocationName { get; set; }

        public ICollection<TrBpkb> TrBpkbs { get; set; }
    }
}

