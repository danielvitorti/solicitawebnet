namespace solicita_web_net.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sol_anexos
    {
        [Key]
        public long sol_anexos_id { get; set; }

        public long sol_solicitacao_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string sol_arquivo_anexo { get; set; }

        public DateTime sol_arquivo_anexo_data_cadastro { get; set; }
    }
}
