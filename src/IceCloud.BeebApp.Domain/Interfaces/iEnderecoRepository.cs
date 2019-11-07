using System.Collections.Generic;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Domain.Interfaces
{
    public interface IEnderecoRepository : IRepositoryRead<Endereco>, IRepositoryWrite<Endereco>
    {
        IEnumerable<Endereco> GetAtivos();
        Endereco GetByCEP(string cep);
    }
}