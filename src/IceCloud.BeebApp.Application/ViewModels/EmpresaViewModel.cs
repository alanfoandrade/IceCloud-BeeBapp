using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IceCloud.BeebApp.Application.ViewModels
{
    public class EmpresaViewModel
    {
        public EmpresaViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome Fantasia")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(14, ErrorMessage = "Máximo 14 caracteres")]
        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(11, ErrorMessage = "Máximo 11 caracteres")]
        [DisplayName("Telefone")]
        public string TEL { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public bool Excluido { get; set; }

    }
}