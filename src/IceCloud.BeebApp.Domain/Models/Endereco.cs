using System;

namespace IceCloud.BeebApp.Domain.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        
        public virtual Empresa Empresa { get; set; }



        // Validações
        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Logradouro))
                AddValidationError("Logradouro", "Logradouro não pode estar em branco");

            if (string.IsNullOrWhiteSpace(CEP))
                AddValidationError("CEP", "CEP não pode estar em branco");

            return ValidationResult.Count == 0;
        }
    }
}
