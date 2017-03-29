namespace solicita_web_net.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sol_solicitante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sol_solicitante()
        {
            sol_solicitacao = new HashSet<sol_solicitacao>();
            this.sol_data_cadastro = DateTime.Now;
        }

        [Key]
        public int sol_id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string sol_nome { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string sol_email { get; set; }

        [StringLength(100)]
        [Display(Name = "Foto")]
        public string sol_foto { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string sol_telefone { get; set; }

        [StringLength(20)]
        [Display(Name = "Celular")]
        public string sol_celular { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Função")]
        public string sol_funcao { get; set; }

        public DateTime? sol_data_cadastro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sol_solicitacao> sol_solicitacao { get; set; }


        //[DataType(DataType.PhoneNumber)]
    }
}
