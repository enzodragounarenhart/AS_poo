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
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILivroRepository _livroRepository;

        public UsuarioController(IUsuarioRepository repository, IMapper mapper, ILivroRepository livroRepository)
        {
            _mapper = mapper;
            _usuarioRepository = repository;
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var Usuarios = _usuarioRepository.GetAll();
            var UsuariosDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(Usuarios);
            return Ok(new {statusCode = 200, message = "OK",UsuariosDTO});
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> Get(int id)
        {
            var Usuario = _usuarioRepository.GetById(id);
            
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
            _usuarioRepository.Save(Usuario);
            return Ok(new { statusCode = 200, message = "Usuario cadastrado com sucesso.", Usuario});
        }

        [HttpPost("{usuarioId}/emprestar/{livroId}", Name = "EmprestarLivro")]
        public ActionResult EmprestarLivro(int usuarioId, int livroId)
        {
            var usuario = _usuarioRepository.GetById(usuarioId);
            var livro = _livroRepository.GetById(livroId);

            if(usuario == null || livro == null)
            {
                return Ok(new { statusCode = 400, message = "Usuario ou livro nao encontrados."});
            }

            if(livro.emprestado == 1)
            {
                return Ok(new { statusCode = 400, message = "Livro ja emprestado."});
            }

            livro.emprestado = 1;
            livro.UsuarioId = usuarioId;

            usuario.LivrosEmprestados.Add(livro);

            _livroRepository.Update(livro);
            _usuarioRepository.Update(usuario);

            return Ok(new { StatusCode = 200, Message = "Livro emprestado com sucesso." });

        }

        [HttpPost("{usuarioId}/devolver/{livroId}", Name = "DevolverLivro")]
        public ActionResult DevolverLivro(int usuarioId, int livroId)
        {
            var usuario = _usuarioRepository.GetById(usuarioId);
            var livro = _livroRepository.GetById(livroId);

            if(usuario == null || livro == null)
            {
                return Ok(new { statusCode = 400, message = "Usuario ou livro nao encontrados."});
            }

            if(livro.emprestado == 0 || livro.UsuarioId != usuarioId)
            {
                return Ok(new { statusCode = 400, message = "Livro nao esta emprestado para este usuario."});
            }

            livro.emprestado = 0;
            livro.UsuarioId = null;

            usuario.LivrosEmprestados.Remove(livro);

            _livroRepository.Update(livro);
            _usuarioRepository.Update(usuario);

            return Ok(new { StatusCode = 200, Message = "Livro devolvido com sucesso." });

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UsuarioDTO UsuarioDTO)
        {
            if(id != UsuarioDTO.Id)
            {
                return Ok(new {statusCode = 400, message = "IDs NAO SAO IGUAIS"+ id, UsuarioDTO.Id});
            }

            var Usuario = _usuarioRepository.GetById(id);
            if (Usuario == null)
            {
                 return Ok(new { statusCode = 400, message = "Não foi encontrada o Usuario com id: "+ id,Usuario});
            }
            _mapper.Map(UsuarioDTO, Usuario);
            _usuarioRepository.Update(Usuario);
            return Ok(new { statusCode = 200, message = "Usuario atualizado com sucesso", Usuario});

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(_usuarioRepository.Delete(id))
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