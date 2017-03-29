namespace solicita_web_net.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sol_causas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sol_causas()
        {
            sol_solicitacao = new HashSet<sol_solicitacao>();
        }

        [Key]
        public int sol_causa_id { get; set; }

        [Required]
        [StringLength(100)]
        public string sol_causa_descricao { get; set; }

        public DateTime sol_causa_data_cadastro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sol_solicitacao> sol_solicitacao { get; set; }
    }
}