namespace ModelChannelMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Gravador
    {
        public int id_plataforma { get; set; }

        [Key]
        public int id_gravador { get; set; }

        public int id_tipogravador { get; set; }

        public int serial { get; set; }

        [StringLength(50)]
        public string hostname { get; set; }

        [StringLength(50)]
        public string Ip { get; set; }

        [StringLength(50)]
        public string usuario { get; set; }

        [StringLength(50)]
        public string senha { get; set; }

        [StringLength(50)]
        public string userfieldExtension { get; set; }

        [StringLength(50)]
        public string PP { get; set; }

        [StringLength(50)]
        public string operacao { get; set; }

        [StringLength(4)]
        public string recorderType { get; set; }

        public virtual tbl_Plataforma tbl_Plataforma { get; set; }

        public virtual tbl_TipoGravador tbl_TipoGravador { get; set; }
    }
}
