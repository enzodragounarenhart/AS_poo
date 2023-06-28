using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_poo.Data.Repositories;
using AS_poo.Domain.Entities;
using AS_poo.Domain.Interfaces;
using AS_poo.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace AS_poo.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class LivroController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILivroRepository _repository;

        public LivroController(ILivroRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Livro>> Get()
        {
            var livros = _repository.GetAll();
            var livrosDTO = _mapper.Map<IEnumerable<LivroDTO>>(livros);
            return Ok(new {statusCode = 200, message = "OK",livrosDTO});
        }

        [HttpGet("{id}")]
        public ActionResult<LivroDTO> Get(int id)
        {
            var livro = _repository.GetById(id);
            
            if(livro == null)
            {
                return Ok(new { statusCode = 400, message = "Não foi encontrada o livro com id: "+ id,livro});
            }
            else
            {
                var livroDTO = _mapper.Map<LivroDTO>(livro);
                return Ok(new {statusCode = 200, message = "OK", livroDTO});
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]LivroDTO livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            _repository.Save(livro);
            return Ok(new { statusCode = 200, message = "Livro cadastrado com sucesso.", livro});
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LivroDTO livroDTO)
        {
            if(id != livroDTO.Id)
            {
                return Ok(new {statusCode = 400, message = "IDs NAO SAO IGUAIS"+ id, livroDTO.Id});
            }

            var livro = _repository.GetById(id);
            if (livro == null)
            {
                 return Ok(new { statusCode = 400, message = "Não foi encontrada o livro com id: "+ id,livro});
            }
            _mapper.Map(livroDTO, livro);
            _repository.Update(livro);
            return Ok(new { statusCode = 200, message = "Livro atualizado com sucesso", livro});

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(_repository.Delete(id))
            {
                return Ok(new {StatusCode = 200, message = "Livro deletado com sucesso"});
            }
            else
            {
                return Ok(new {StatusCode = 500, message = "Algo deu errado, tente novamente"});
            }
        }
        
    }
}