using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BpkbApi.Models
{
	public class MsStorageLocation
	{
        [Key]
        [StringLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        public string LocationId { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string LocationName { get; set; }

        public ICollection<TrBpkb> TrBpkbs { get; set; }
    }
}

