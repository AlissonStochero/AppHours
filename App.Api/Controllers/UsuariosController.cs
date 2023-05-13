using App.Domain.DTO;
using App.Domain.Entidade;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        private IUsuariosService _service;
        public UsuariosController(IUsuariosService service)
        {
            _service = service;
        }

        [HttpGet("ListaUsuarios")]
        public JsonResult ListaUsuarios(string busca)
        {
            try
            {
                var obj = _service.ListaUsuarios();
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
        [HttpPost("Salvar")]
        public JsonResult Salvar(string nome, string email, string senha)
        {
            var obj = new Usuarios
            {
                Nome = nome,
                Email = email,
                Senha = senha
            };
            _service.Salvar(obj);
            return Json(true);
        }
    }
}
