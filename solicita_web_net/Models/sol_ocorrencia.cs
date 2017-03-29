namespace solicita_web_net.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sol_ocorrencia
    {
        [Key]
        public short sol_ocorrencia_id { get; set; }

        [Required]
        [StringLength(100)]
        public string sol_ocorrencia_descricao { get; set; }

        public DateTime sol_ocorrencia_data_cadastro { get; set; }
    }
}
