using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    /// <summary>
    /// test
    /// </summary>
    /// <param name= "loginViewModelInput"></param>
    ///<returns></returns>
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("logar")]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
            return Created("", loginViewModelInput);
        }

    }
}