using System;
using System.Collections.Generic;

namespace IceCloud.BeebApp.Domain.Models
{
    public class Empresa : Entity
    {
        public Empresa()
        {
            Departamentos = new List<Departamento>();
            Produtos = new List<Produto>();
            Usuarios = new List<Usuario>();
            Enderecos = new List<EnderecoEmpresa>();
        }
        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public string TEL { get; set; }


        // Relacionamentos
        // Empresa:Usuario (1:N)
        public virtual ICollection<Usuario> Usuarios { get; set; }
        // Empresa:Produto (1:N)
        public virtual ICollection<Produto> Produtos { get; set; }
        // Empresa:Departamento (1:N)
        public virtual ICollection<Departamento> Departamentos { get; set; }
        // Empresa:Endereco (1:N)
        public virtual ICollection<EnderecoEmpresa> Enderecos { get; set; }

        public void AddEndereco(EnderecoEmpresa endereco)
        {
            if (!endereco.IsValid())
            {
                ValidationResult = endereco.ValidationResult;
                return;
            }

            Enderecos.Add(endereco);
        }

        public void AddUsuario(Usuario usuario)
        {
            if (!usuario.IsValid())
            {
                ValidationResult = usuario.ValidationResult;
                return;
            }
            Usuarios.Add(usuario);
        }

        public void AddProduto(Produto produto)
        {
            if (!produto.IsValid())
            {
                ValidationResult = produto.ValidationResult;
                return;
            }

            Produtos.Add(produto);
        }

        public void AddDepartamento(Departamento departamento)
        {
            if (!departamento.IsValid())
            {
                ValidationResult = departamento.ValidationResult;
                return;
            }

            Departamentos.Add(departamento);
        }


        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(NomeFantasia))
                AddValidationError("NomeFantasia", "NomeFantasia não pode estar em branco");

            if (string.IsNullOrWhiteSpace(CNPJ))
                AddValidationError("CNPJ", "CNPJ não pode estar em branco");

            return ValidationResult.Count == 0;
        }
    }
}