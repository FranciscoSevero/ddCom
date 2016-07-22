namespace ModelChannelMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Plataforma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Plataforma()
        {
            tbl_Gravador = new HashSet<tbl_Gravador>();
            tbl_Ramal = new HashSet<tbl_Ramal>();
        }

        public int id_site { get; set; }

        [Key]
        public int id_plataforma { get; set; }

        [StringLength(50)]
        public string plataforma { get; set; }

        [StringLength(100)]
        public string instanciaSql { get; set; }

        [StringLength(50)]
        public string usuarioSql { get; set; }

        [StringLength(50)]
        public string senhaSql { get; set; }

        [StringLength(55)]
        public string ip { get; set; }

        public int? ociosidade { get; set; }

        public DateTime? cadastro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Gravador> tbl_Gravador { get; set; }

        public virtual tbl_RamalEmAnalise tbl_Sites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Ramal> tbl_Ramal { get; set; }
    }
}
