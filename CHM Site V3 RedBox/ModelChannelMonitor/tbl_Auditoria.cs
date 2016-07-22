namespace ModelChannelMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Auditoria
    {
        public int id { get; set; }

        public int id_usuario { get; set; }

        [Required]
        public string acao { get; set; }

        public DateTime data_acao { get; set; }

        public virtual tbl_Usuarios tbl_Usuarios { get; set; }
    }
}
