namespace ModelChannelMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Email
    {
        public int id { get; set; }

        public int id_servidor { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string senha { get; set; }

        [Required]
        [StringLength(100)]
        public string smtp { get; set; }

        [Required]
        [StringLength(5)]
        public string porta { get; set; }

        [StringLength(50)]
        public string copia { get; set; }

        public DateTime data_envio { get; set; }
    }
}
