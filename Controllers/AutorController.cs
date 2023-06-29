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

    public class AutorController : ControllerBase
    {
        
        private readonly IAutorRepository _repository;
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public AutorController(IAutorRepository repository, ILivroRepository livroRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            var Autors = _repository.GetAll();
            var AutorsDTO = _mapper.Map<IEnumerable<AutorDTO>>(Autors);
            return Ok(new {statusCode = 200, message = "OK",AutorsDTO});
        }

        [HttpGet("{id}")]
        public ActionResult<AutorDTO> Get(int id)
        {
            var Autor = _repository.GetById(id);
            
            if(Autor == null)
            {
                return Ok(new { statusCode = 400, message = "Não foi encontrada o Autor com id: "+ id,Autor});
            }
            else
            {
                var AutorDTO = _mapper.Map<AutorDTO>(Autor);
                return Ok(new {statusCode = 200, message = "OK", AutorDTO});
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]AutorDTO AutorDTO)
        {
            var Autor = _mapper.Map<Autor>(AutorDTO);
            _repository.Save(Autor);
            return Ok(new { statusCode = 200, message = "Autor cadastrado com sucesso.", Autor});
        }

        /*[HttpPut("{autorId}/livros/{livroId}")]
        public ActionResult AddLivro(int autorId, int livroId)
        {
            var autor = _repository.GetById(autorId);
            var livro = _livroRepository.GetById(livroId);

            if (autor == null || livro == null)
            {
                return Ok(new { statusCode = 400, message = "Não foi encontrada o livro ou o autor: "});
            }

            autor.Livros.Add(livro);
            _repository.Update(autor);

            return Ok(new { statusCode = 200, message = "Autor atualizado com sucesso", autor});
        }*/

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AutorDTO AutorDTO)
        {
            if(id != AutorDTO.Id)
            {
                return Ok(new {statusCode = 400, message = "IDs NAO SAO IGUAIS"+ id, AutorDTO.Id});
            }

            var Autor = _repository.GetById(id);
            if (Autor == null)
            {
                 return Ok(new { statusCode = 400, message = "Não foi encontrada o Autor com id: "+ id,Autor});
            }
            _mapper.Map(AutorDTO, Autor);
            _repository.Update(Autor);
            return Ok(new { statusCode = 200, message = "Autor atualizado com sucesso", Autor});

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_repository.Delete(id))
            {
                return Ok(new {StatusCode = 200, message = "Autor deletado com sucesso"});
            }
            else
            {
                return Ok(new {StatusCode = 500, message = "Algo deu errado, tente novamente"});
            }
        }
        
    }
}