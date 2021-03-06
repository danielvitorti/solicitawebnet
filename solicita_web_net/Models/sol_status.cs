namespace solicita_web_net.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sol_status
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sol_status()
        {
            sol_solicitacao = new HashSet<sol_solicitacao>();
            this.sol_status_data_cadastro = DateTime.Now;
        }

        [Key]
        public int sol_status_id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descri��o")]
        public string sol_status_descricao { get; set; }

        public DateTime sol_status_data_cadastro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sol_solicitacao> sol_solicitacao { get; set; }
    }
}
