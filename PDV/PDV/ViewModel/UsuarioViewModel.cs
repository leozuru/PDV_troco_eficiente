using PDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.ViewModel
{
    public class UsuarioViewModel : Usuario
    {
        public UsuarioViewModel()
        {

        }

        public UsuarioViewModel(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
        }

    }
}
