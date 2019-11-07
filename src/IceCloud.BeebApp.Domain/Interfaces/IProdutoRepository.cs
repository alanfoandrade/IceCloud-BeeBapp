using System.Collections.Generic;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryRead<Produto>, IRepositoryWrite<Produto>
    {
        IEnumerable<Produto> GetAtivos();
        Produto GetByNome(string nome);
    }
}