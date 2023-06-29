using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_poo.Data.Repositories;
using AS_poo.Domain.Entities;
using AS_poo.Domain.Interfaces;
using AS_poo.Domain.DTOs;
using AS_poo.Domain.ViewModels;
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
        private readonly IAutorRepository _autorRepository;

        public LivroController(ILivroRepository repository, IUsuarioRepository usuarioRepository, IAutorRepository autorRepository, IMapper mapper)
        {
            _mapper = mapper;
           _autorRepository = autorRepository;
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
        public ActionResult Post([FromBody]LivroViewModel livroVM)
        {
            var livro = _mapper.Map<Livro>(livroVM);
            _repository.Save(livro);
            return Ok(new { statusCode = 200, message = "Livro cadastrado com sucesso.", livro});
        }

        /*[HttpPut("{livroId}/autores/{autorId}")]
        public ActionResult AddAutor(int autorId, int livroId)
        {
            var autor = _autorRepository.GetById(autorId);
            var livro = _repository.GetById(livroId);

            if (autor == null || livro == null)
            {
                return Ok(new { statusCode = 400, message = "Não foi encontrada o livro ou o autor: "});
            }

            livro.Autores.Add(autor);
            _repository.Update(livro);

            return Ok(new { statusCode = 200, message = "Livro atualizado com sucesso", livro});
        }*/

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]LivroViewModel livroVM)
        {
            var livro = _mapper.Map<Livro>(livroVM);

            if(id != livro.Id)
            {
                return Ok(new {statusCode = 400, message = "IDs NAO SAO IGUAIS"+ id, livro.Id});
            }


            if (livro == null)
            {
                 return Ok(new { statusCode = 400, message = "Não foi encontrada o livro com id: "+ id,livro});
            }
            _repository.Update(livro);
            return Ok(new { statusCode = 200, message = "Livro atualizado com sucesso", livro});

        }

        [HttpDelete("{id}")]
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