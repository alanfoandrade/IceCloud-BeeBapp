using AutoMapper;
using IceCloud.BeebApp.Application.ViewModels;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Application.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<EnderecoUsuario, EnderecoDeUsuarioViewModel>().ReverseMap();
            CreateMap<EnderecoEmpresa, EnderecoDeEmpresaViewModel>().ReverseMap();
            CreateMap<TipoUsuario, TipoUsuarioViewModel>().ReverseMap();
            CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
            CreateMap<Departamento, DepartamentoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}