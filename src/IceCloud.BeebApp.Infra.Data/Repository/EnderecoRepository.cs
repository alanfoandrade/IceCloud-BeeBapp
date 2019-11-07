using System.Collections.Generic;
using System.Linq;
using IceCloud.BeebApp.Domain.Interfaces;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public IEnumerable<Endereco> GetAtivos()
        {
            return Buscar(e => e.Ativo);
        }

        public Endereco GetByCEP(string cep)
        {
            return Buscar(e => e.CEP == cep).FirstOrDefault();
        }

    }
}