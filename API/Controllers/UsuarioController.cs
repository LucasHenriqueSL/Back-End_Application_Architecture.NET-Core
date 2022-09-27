using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Filters;
using System.Security.Claims;
using API.Models;
using API.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using API.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using API.Business.Entities;
using API.Business.Repositories;
using API.Infraestrutura.Data.Repository;
using Microsoft.Extensions.Configuration;
using API.Configurations;

namespace API.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController] 
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;
       
        private readonly IAuthenticationService _authenticationService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IAuthenticationService authenticationService)
        {
            _usuarioRepository = usuarioRepository;
       
            _authenticationService = authenticationService;
        }


        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <param name= "loginViewModelInput">View model do login</param>
        ///<returns>Retorna status ok, dados do usuario e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autentica", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]

        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {

           var usuario =  _usuarioRepository.ObterUsuario(loginViewModelInput.Login);

            if(usuario == null)
            {
                return BadRequest("Houve um erro ao tentar acessar");
            }
            //if(usuario.Senha != loginViewModelInput.Senha.GerarSenhaCriptografada())
            //{
            //    return BadRequest("Houve um erro ao tentar acessar");
            //}
            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = usuario.Codigo,
                Login = loginViewModelInput.Login,
                Email = usuario.Email
            };


            
           
            var token = _authenticationService.GerarToken(usuarioViewModelOutput);

            return Ok(new { 
            Token = token,
            Usuario = usuarioViewModelOutput
            });
        }


        /// <summary>
        /// Este serviço permite cadastrar um usuário cadastrado não existente
        /// </summary>
        /// <param name="registro">View Model do registro do login</param>
      
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autentica", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
           


            //var migracoesPendentes = contexto.Database.GetPendingMigrationsAsync();
            //if(migracoesPendentes.Count() > 0)
            //{
            //    contexto.Database.Migrate();
            //}


            var usuario = new Usuario();
            usuario.Login = loginViewModelInput.Login;
            usuario.Senha = loginViewModelInput.Senha;
            usuario.Email = loginViewModelInput.Email;      

            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();



            return Created("", loginViewModelInput);
        }

    }
} 