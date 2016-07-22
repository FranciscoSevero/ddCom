namespace ModelChannelMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Ramal
    {
        public int id_site { get; set; }

        public int id_plataforma { get; set; }

        public int id_gravador { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ramal { get; set; }

        [StringLength(50)]
        public string ip { get; set; }

        public DateTime? ultima { get; set; }

        public DateTime? atual { get; set; }

        public long diferenca { get; set; }

        public int id_status { get; set; }

        [StringLength(100)]
        public string eventos { get; set; }

        [StringLength(50)]
        public string extension { get; set; }

        public virtual tbl_Plataforma tbl_Plataforma { get; set; }

        public virtual tbl_Status tbl_Status { get; set; }
    }
}
