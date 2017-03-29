namespace solicita_web_net.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sol_comentario
    {
        [Key]
        public int sol_comentario_id { get; set; }

        public long sol_solicitacao_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string sol_descricao_comentario { get; set; }

        public int sol_status_id { get; set; }

        public int sol_responsavel_id { get; set; }

        public DateTime sol_comentario_data_cadastro { get; set; }
    }
}
