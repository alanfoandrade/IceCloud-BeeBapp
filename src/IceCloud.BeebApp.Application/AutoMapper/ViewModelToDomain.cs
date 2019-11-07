using AutoMapper;
using IceCloud.BeebApp.Application.ViewModels;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Application.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            // Já implementado em DomainToViewModel usando o .ReverseMap()
        }
    }
}