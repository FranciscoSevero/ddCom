namespace ModelChannelMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Sites
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Sites()
        {
            tbl_Plataforma = new HashSet<tbl_Plataforma>();
        }

        [Key]
        public int id_site { get; set; }

        [Required]
        [StringLength(50)]
        public string site { get; set; }

        [StringLength(100)]
        public string info_adicional { get; set; }

        public DateTime cadastro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Plataforma> tbl_Plataforma { get; set; }
    }
}
