using PDV.Models;
using PDV.Repository;
using PDV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioViewModel> GetById(long Id)
        {
            try
            {
                UsuarioViewModel usuarioViewModel = new UsuarioViewModel(await usuarioRepository.GetById(Id));
                return usuarioViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<UsuarioViewModel>> GetList()
        {
            try
            {
                List<UsuarioViewModel> ListaUsuarios = new List<UsuarioViewModel>();

                IEnumerable<Usuario> usuarios = await usuarioRepository.GetList();
                foreach (Usuario usuario in usuarios)
                {
                    ListaUsuarios.Add(new UsuarioViewModel(usuario));
                }

                return ListaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                Usuario usuario = MontarUsuario(usuarioViewModel);

                return await usuarioRepository.Insert(usuario);

            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public async Task<bool> Remove(long Id)
        {
            try
            {
                await usuarioRepository.Remove(Id);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                Usuario usuario = MontarUsuario(usuarioViewModel);

                await usuarioRepository.Update(usuario);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario MontarUsuario(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Id = usuarioViewModel.Id,
                    Nome = usuarioViewModel.Nome
                };

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
