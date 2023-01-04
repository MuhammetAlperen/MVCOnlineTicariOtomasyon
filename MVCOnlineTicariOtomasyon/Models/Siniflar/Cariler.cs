using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariAd { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSoyad { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSehir { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareketleri> satisHareketleris { get; set; }
    }
}