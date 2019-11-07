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
    public class ProdutoAppService : AppServiceBase, IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAppService()
        {
            _produtoRepository = new ProdutoRepository();
        }

        public IEnumerable<ProdutoViewModel> GetAtivos()
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.GetAtivos());
        }

        public ProdutoViewModel GetByNome(string nome)
        {
            return Mapper.Map<ProdutoViewModel>(_produtoRepository.GetByNome(nome));
        }

        public ProdutoViewModel GetById(Guid id)
        {
            return Mapper.Map<ProdutoViewModel>(_produtoRepository.GetById(id));
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.GetAll());
        }

        public ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);

            produto.SetAtivo();

            if (!produto.IsValid()) return produtoViewModel;

            _produtoRepository.Adicionar(produto);
            return produtoViewModel;
        }

        public ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<Produto>(produtoViewModel);

            if (!produto.IsValid()) return produtoViewModel;

            _produtoRepository.Atualizar(produto);
            return produtoViewModel;
        }

        public void Remover(Guid id)
        {
            _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}