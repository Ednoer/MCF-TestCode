using System;
using System.ComponentModel.DataAnnotations;

namespace BpkbApi.Models
{
	public class MsUser
	{
        [Key]
        public long UserId { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}

