namespace solicita_web_net.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sol_responsavel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sol_responsavel()
        {
            sol_solicitacao = new HashSet<sol_solicitacao>();
            this.sol_responsavel_data_cadastro = DateTime.Now;
        }

        [Key]
        public int sol_responsavel_id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Nome")]
        public string sol_responsavel_nome { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Cargo")]
        public string sol_responsavel_cargo { get; set; }

        public DateTime sol_responsavel_data_cadastro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sol_solicitacao> sol_solicitacao { get; set; }
    }
}
