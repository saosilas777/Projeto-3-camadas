using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Silas.API.Models;
using Silas.API.Services;
using System;
using System.Threading.Tasks;

namespace Silas.API.Controllers
{
    public class AuthenticationController : Controller
    {

        [HttpPost("Authentication")]
        [ProducesResponseType (typeof (bool), 200)]
        [ProducesResponseType (typeof (string), 500)]
        public async Task<object> Authentication([FromBody] UserModels user)
        {
            try
            {
                AuthenticationServices authentication = new AuthenticationServices();

                return authentication.AuthenticationUser(user);
            }
            catch(Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        //TODO
        //Controller users: criar, alterar, desativar
        //estrutura de dados: criar tabela para acomodar roles(id"como inteiro", descripytion) e scopes(id "como inteiro", descripytion)
        //criar tabelas de roles e scope(admin...)
        //criar camada servicos na api, para criar usuarios e ver se role e scope existe no banco
        //

    }
}
