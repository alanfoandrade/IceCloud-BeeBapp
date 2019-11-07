using System;
using System.Collections.Generic;
using AutoMapper;
using IceCloud.BeebApp.Application.Interfaces;
using IceCloud.BeebApp.Application.ViewModels;
using IceCloud.BeebApp.Domain.Interfaces;
using IceCloud.BeebApp.Domain.Models;
using IceCloud.BeebApp.Infra.Data.Repository;

namespace IceCloud.BeebApp.Application.Services
{
    public class UsuarioAppService : AppServiceBase, IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public IEnumerable<UsuarioViewModel> GetAtivos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepository.GetAtivos());
        }

        public UsuarioViewModel GetByCpf(string cpf)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioRepository.GetByCpf(cpf));
        }

        public UsuarioViewModel GetByEmail(string email)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioRepository.GetByEmail(email));
        }

        public UsuarioViewModel GetById(Guid id)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioRepository.GetById(id));
        }

        public IEnumerable<UsuarioViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepository.GetAll());
        }

        public UsuarioEnderecoTipoViewModel Adicionar(UsuarioEnderecoTipoViewModel usuarioEnderecoTipoViewModel)
        {
            var usuario = Mapper.Map<Usuario>(usuarioEnderecoTipoViewModel.Usuario);
            var endereco = Mapper.Map<EnderecoUsuario>(usuarioEnderecoTipoViewModel.Endereco);
            var tipo = Mapper.Map<TipoUsuario>(usuarioEnderecoTipoViewModel.TipoUsuario);

            usuario.SetAtivo();
            endereco.SetAtivo();
            tipo.SetAtivo();
            usuario.AddEndereco(endereco);
            usuario.AddTipo(tipo);

            if (!usuario.IsValid()) return usuarioEnderecoTipoViewModel;

            _usuarioRepository.Adicionar(usuario);
            return usuarioEnderecoTipoViewModel;
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = Mapper.Map<Usuario>(usuarioViewModel);

            if (!usuario.IsValid()) return usuarioViewModel;

            _usuarioRepository.Atualizar(usuario);
            return usuarioViewModel;
        }

        public void Remover(Guid id)
        {
            _usuarioRepository.Remover(id);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }

    }
}