using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_poo.Data.Repositories;
using AS_poo.Domain.Entities;
using AS_poo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AS_poo.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        
        private readonly IUsuarioRepository _repository;

        public UsuarioController()
        {
            _repository = new UsuarioRepository();
        }

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _repository.GetById(id);
            if(item == null)
            {
                return Ok(new { statusCode = 400, message = "Não foi encontrada o usuário com id: "+ id,item});
            }
            else
            {
                return Ok(new {statusCode = 200, message = "OK", item});
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Usuario item)
        {
            _repository.Save(item);
            return Ok(new { statusCode = 200, message = "Usuário cadastrado com sucesso.", item});
        }

        [HttpPut]
        public IActionResult Put([FromBody] Usuario item)
        {
            _repository.Update(item);
            return Ok(new { statusCode = 200, message = "Usuário atualizado com sucesso", item});

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(_repository.Delete(id))
            {
                return Ok(new {StatusCode = 200, message = "Usuário deletado com sucesso"});
            }
            else
            {
                return Ok(new {StatusCode = 500, message = "Algo deu errado, tente novamente"});
            }
        }
        
    }
}