using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpkbApi.Models
{
	public class MsUser
	{
        [Key]
        public long UserId { get; set; }

        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string UserName { get; set; }

        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}

