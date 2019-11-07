using System;
using System.Collections.Generic;
using IceCloud.BeebApp.Application.ViewModels;

namespace IceCloud.BeebApp.Application.Interfaces
{
    public interface IEmpresaAppService : IDisposable
    {
        EmpresaEnderecoViewModel Adicionar(EmpresaEnderecoViewModel empresaDepartamentoViewModel);
        EmpresaViewModel GetById(Guid id);
        IEnumerable<EmpresaViewModel> GetAll();
        IEnumerable<EmpresaViewModel> GetAtivos();
        EmpresaViewModel GetByCnpj(string cnpj);
        EmpresaViewModel GetByTel(string tel);
        EmpresaViewModel Atualizar(EmpresaViewModel empresaViewModel);
        void Remover(Guid id);
    }
}