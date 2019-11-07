using System;

namespace IceCloud.BeebApp.Application.ViewModels
{
    public class UsuarioEnderecoTipoViewModel
    {
        public UsuarioViewModel Usuario { get; set; }
        public EnderecoDeUsuarioViewModel Endereco { get; set; }
        public TipoUsuarioViewModel TipoUsuario { get; set; }
    }
}