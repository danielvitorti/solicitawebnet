namespace solicita_web_net.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sol_classificacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sol_classificacao()
        {
            sol_solicitacao = new HashSet<sol_solicitacao>();
        }

        [Key]
        public int sol_classificacao_id { get; set; }

        [Required]
        [StringLength(100)]
        public string sol_classificacao_descricao { get; set; }

        public DateTime sol_classificacao_data_cadastro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sol_solicitacao> sol_solicitacao { get; set; }
    }
}
