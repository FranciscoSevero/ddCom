namespace ModelChannelMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Usuarios()
        {
            tbl_Auditoria = new HashSet<tbl_Auditoria>();
        }

        [Key]
        public int id_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string nome_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string login { get; set; }

        [Required]
        [StringLength(50)]
        public string senha { get; set; }

        public DateTime data_cadastro { get; set; }

        public int id_status { get; set; }

        [Required]
        [StringLength(50)]
        public string nivel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Auditoria> tbl_Auditoria { get; set; }
    }
}
