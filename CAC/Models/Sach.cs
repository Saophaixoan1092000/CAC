namespace CAC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Tieude { get; set; }

        [StringLength(100)]
        public string Hinh { get; set; }

        [StringLength(50)]
        public string Noidung { get; set; }

        public decimal? Gia { get; set; }

        public int? Tacgia { get; set; }

        public int? Theloai { get; set; }

        public virtual Tacgia Tacgia1 { get; set; }

        public virtual TheLoai TheLoai1 { get; set; }
    }
}
