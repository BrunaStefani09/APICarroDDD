using AulaProjetoFinal.Domain.Entities;
using AulaProjetoFinal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaProjetoFinal.Domain.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public User GetByEmailPassword(Usuario usuario)
        {
            var result = _usuarioRepository.GetByEmailPassword(usuario);
            if (result != null)
            {
                User user = new User
                {
                    Email = result.Email,
                    Password = result.Password,
                    Role = result.Role
                };

                return user;
            }
            return new User();
        }
    }
}
