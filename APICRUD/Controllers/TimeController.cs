using CRUD;
using CRUD.Aplicacao;
using CRUD.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace APICRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController:ControllerBase
    {
        private readonly TimeService _service;
        public TimeController(IConfiguration configuration) 
        {
            _service = new TimeService (configuration);
        }

        [HttpPost("adicionar-time")]
        public void AdicionarTime(Time t)
        {
            _service.Adicionar(t);
        }

        [HttpGet("listar-time")]
        public List<Time> ListarTime()
        {
            return _service.Listar();
        }

        [HttpDelete("Remover-time")]
        public void RemoverTime(int id)
        {
            _service.Remover(id);
        }

        [HttpPut("Editar-time")]
        public void EditarTime(int id, Time time)
        {
            _service.Editar(id,time);
        }
    }
}
