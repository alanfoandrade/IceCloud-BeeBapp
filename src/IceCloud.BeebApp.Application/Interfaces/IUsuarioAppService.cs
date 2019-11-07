using System;
using System.Collections.Generic;
using IceCloud.BeebApp.Application.ViewModels;

namespace IceCloud.BeebApp.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        UsuarioEnderecoTipoViewModel Adicionar(UsuarioEnderecoTipoViewModel usuarioEnderecoTipo);
        UsuarioViewModel GetById(Guid id);
        IEnumerable<UsuarioViewModel> GetAll();
        IEnumerable<UsuarioViewModel> GetAtivos();
        UsuarioViewModel GetByCpf(string cpf);
        UsuarioViewModel GetByEmail(string email);
        UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel);
        void Remover(Guid id);
    }
}