using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BpkbMvc.Models
{
    public class TrBpkbModel
    {
        [StringLength(100)]
        [DisplayName("Agreement Number")]
        public string AgreementNumber { get; set; }

        [StringLength(100)]
        [DisplayName("No. BPKB")]
        public string BpkbNo { get; set; }

        [StringLength(10)]
        [DisplayName("Cabang")]
        public string BranchId { get; set; }

        [DisplayName("Tanggal BPKB")]
        public DateTime BpkbDate { get; set; }

        [StringLength(100)]
        [DisplayName("No Faktur")]
        public string FakturNo { get; set; }

        [DisplayName("Tanggal Faktur")]
        public DateTime FakturDate { get; set; }

        [DisplayName("Lokasi Penyimpanan")]
        public string LocationId { get; set; }

        [StringLength(20)]
        [DisplayName("Nomor Polisi")]
        public string PoliceNo { get; set; }

        [DisplayName("Tanggal BPKB In")]
        public DateTime BpkbDateIn { get; set; }
    }
}
