namespace solicita_web_net.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sol_solicitacao
    {


        
        [Key]
        public long sol_solicitacao_id { get; set; }

        public int sol_status_id { get; set; }

        public int sol_solicitante_id { get; set; }

        public int sol_tipo_servico_id { get; set; }

        public int sol_categoria_servico_id { get; set; }

        public int sol_urgencia_id { get; set; }

        public int sol_impacto_id { get; set; }

        public int sol_classificacao_id { get; set; }

        public int sol_produto_id { get; set; }

        public int sol_responsavel_id { get; set; }

        public int sol_grupo_resolvedor_id { get; set; }

        public int? sol_causa_id { get; set; }

        public int? sol_sub_causa_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string sol_resumo_solicitacao { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string sol_justificativa_solicitacao { get; set; }

        [Column("sol_solicitacao", TypeName = "text")]
        [Display(Name = "Descrição")]
        [Required]
        public string sol_solicitacao1 { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Solução")]
        public string sol_solucao { get; set; }

        [Display(Name = "Tempo gasto")]
        public TimeSpan? sol_tempo { get; set; }


        public virtual sol_categoria_servico sol_categoria_servico { get; set; }

        public virtual sol_causas sol_causas { get; set; }

        public virtual sol_classificacao sol_classificacao { get; set; }

        public virtual sol_grupo_resolvedor sol_grupo_resolvedor { get; set; }

        public virtual sol_impacto sol_impacto { get; set; }

        public virtual sol_produto sol_produto { get; set; }

        public virtual sol_responsavel sol_responsavel { get; set; }

        public virtual sol_solicitante sol_solicitante { get; set; }

        public virtual sol_status sol_status { get; set; }

        public virtual sol_sub_causas sol_sub_causas { get; set; }

        public virtual sol_tipo_servico sol_tipo_servico { get; set; }

        public virtual sol_urgencia sol_urgencia { get; set; }
    }
}
