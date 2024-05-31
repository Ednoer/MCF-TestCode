using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BpkbApi.Models
{
	public class TrBpkb
	{
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string AgreementNumber { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string BpkbNo { get; set; }

        [StringLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        public string BranchId { get; set; }

        public DateTime BpkbDate { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string FakturNo { get; set; }

        public DateTime FakturDate { get; set; }

        [StringLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        public string LocationId { get; set; }

        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string PoliceNo { get; set; }

        public DateTime BpkbDateIn { get; set; }

        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public MsStorageLocation Location { get; set; }
    }
}

