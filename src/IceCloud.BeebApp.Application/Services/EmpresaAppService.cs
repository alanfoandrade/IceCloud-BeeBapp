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
    public class EmpresaAppService : AppServiceBase, IEmpresaAppService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaAppService()
        {
            _empresaRepository = new EmpresaRepository();
        }

        public IEnumerable<EmpresaViewModel> GetAtivos()
        {
            return Mapper.Map<IEnumerable<EmpresaViewModel>>(_empresaRepository.GetAtivos());
        }

        public EmpresaViewModel GetByCnpj(string cnpj)
        {
            return Mapper.Map<EmpresaViewModel>(_empresaRepository.GetByCnpj(cnpj));
        }

        public EmpresaViewModel GetByTel(string tel)
        {
            return Mapper.Map<EmpresaViewModel>(_empresaRepository.GetByTel(tel));
        }

        public EmpresaViewModel GetById(Guid id)
        {
            return Mapper.Map<EmpresaViewModel>(_empresaRepository.GetById(id));
        }

        public IEnumerable<EmpresaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<EmpresaViewModel>>(_empresaRepository.GetAll());
        }

        public EmpresaEnderecoViewModel Adicionar(EmpresaEnderecoViewModel empresaEnderecoViewModel)
        {
            var empresa = Mapper.Map<Empresa>(empresaEnderecoViewModel.Empresa);
            var endereco = Mapper.Map<EnderecoEmpresa>(empresaEnderecoViewModel.Endereco);

            empresa.SetAtivo();
            endereco.SetAtivo();
            empresa.AddEndereco(endereco);

            if (!empresa.IsValid()) return empresaEnderecoViewModel;

            _empresaRepository.Adicionar(empresa);
            return empresaEnderecoViewModel;
        }

        public EmpresaViewModel Atualizar(EmpresaViewModel empresaViewModel)
        {
            var empresa = Mapper.Map<Empresa>(empresaViewModel);

            if (!empresa.IsValid()) return empresaViewModel;

            _empresaRepository.Atualizar(empresa);
            return empresaViewModel;
        }

        public void Remover(Guid id)
        {
            _empresaRepository.Remover(id);
        }

        public void Dispose()
        {
            _empresaRepository.Dispose();
        }
    }
}