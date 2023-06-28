using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_poo.Data.Repositories;
using AS_poo.Domain.Entities;
using AS_poo.Domain.Interfaces;
using AS_poo.Domain.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AS_poo.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var Usuarios = _repository.GetAll();
            var UsuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(Usuarios);
            return Ok(new {statusCode = 200, message = "OK",UsuariosDTO});
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> Get(int id)
        {
            var Usuario = _repository.GetById(id);
            
            if(Usuario == null)
            {
                return Ok(new { statusCode = 400, message = "Não foi encontrada o Usuario com id: "+ id,Usuario});
            }
            else
            {
                var UsuarioDTO = _mapper.Map<UsuarioDTO>(Usuario);
                return Ok(new {statusCode = 200, message = "OK", UsuarioDTO});
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]UsuarioDTO UsuarioDTO)
        {
            var Usuario = _mapper.Map<Usuario>(UsuarioDTO);
            _repository.Save(Usuario);
            return Ok(new { statusCode = 200, message = "Usuario cadastrado com sucesso.", Usuario});
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioDTO UsuarioDTO)
        {
            if(id != UsuarioDTO.Id)
            {
                return Ok(new {statusCode = 400, message = "IDs NAO SAO IGUAIS"+ id, UsuarioDTO.Id});
            }

            var Usuario = _repository.GetById(id);
            if (Usuario == null)
            {
                 return Ok(new { statusCode = 400, message = "Não foi encontrada o Usuario com id: "+ id,Usuario});
            }
            _mapper.Map(UsuarioDTO, Usuario);
            _repository.Update(Usuario);
            return Ok(new { statusCode = 200, message = "Usuario atualizado com sucesso", Usuario});

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(_repository.Delete(id))
            {
                return Ok(new {StatusCode = 200, message = "Usuario deletado com sucesso"});
            }
            else
            {
                return Ok(new {StatusCode = 500, message = "Algo deu errado, tente novamente"});
            }
        }
        
    }
}