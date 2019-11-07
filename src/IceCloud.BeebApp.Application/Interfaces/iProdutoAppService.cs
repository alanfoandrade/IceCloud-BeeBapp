using System;
using System.Collections.Generic;
using IceCloud.BeebApp.Application.ViewModels;

namespace IceCloud.BeebApp.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        ProdutoViewModel Adicionar(ProdutoViewModel produtoViewModel);
        ProdutoViewModel GetById(Guid id);
        IEnumerable<ProdutoViewModel> GetAll();
        IEnumerable<ProdutoViewModel> GetAtivos();
        ProdutoViewModel GetByNome(string nome);
        ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel);
        void Remover(Guid id);
    }
}