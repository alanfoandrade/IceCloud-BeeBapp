using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using IceCloud.BeebApp.Domain.Interfaces;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public IEnumerable<Usuario> GetAtivos()
        {
            const string sql = @"SELECT * FROM Operacional.Usuarios u " +
                               "WHERE u.Excluido = 0 AND u.Ativo = 1";

            return Db.Database.Connection.Query<Usuario>(sql);
            //return Buscar(u => u.Ativo);
        }

        public Usuario GetByCpf(string cpf)
        {
            return Buscar(u => u.CPF == cpf).FirstOrDefault();
        }

        public Usuario GetByEmail(string email)
        {
            return Buscar(u => u.Email == email).FirstOrDefault();
        }

        public override Usuario GetById(Guid id)
        {
            const string sql = @"SELECT * FROM Operacional.Usuarios u " +
                               "LEFT JOIN Operacional.EnderecosUsuarios e " +
                               "ON u.Id = @uid " +
                               "AND u.Excluido = 0 AND u.Ativo = 1";

            return Db.Database.Connection.Query<Usuario, EnderecoUsuario, Usuario>(sql,
                (u, e) =>
                {
                    u.AddEndereco(e);
                    return u;
                }, new { uid = id }).FirstOrDefault();

            //return Db.Usuarios.AsNoTracking().Include("Enderecos").FirstOrDefault(u => u.Id == id);
        }

        public override void Remover(Guid id)
        {
            var Usuario = GetById(id);
            Usuario.SetExcluido();

            Atualizar(Usuario);
        }
    }
}