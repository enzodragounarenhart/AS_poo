using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AS_poo.Domain.DTOs;
using AS_poo.Domain.Entities;
using AS_poo.Domain.ViewModels;

namespace WebApi.Configuration
{
    public class AutoMapperDTOs : Profile
    {
        public AutoMapperDTOs()
        {
            CreateMap<LivroDTO, Livro>().PreserveReferences().MaxDepth(0);
            CreateMap<AutorDTO, Autor>().PreserveReferences().MaxDepth(0);
            CreateMap<UsuarioDTO, Usuario>().PreserveReferences().MaxDepth(0);
            CreateMap<Livro, LivroDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<Autor, AutorDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<Usuario, UsuarioDTO>().PreserveReferences().MaxDepth(0);
        
        }
    }

    public class AutoMapperViewModels : Profile
    {
        public AutoMapperViewModels()
        {
            CreateMap<LivroViewModel, Livro>();
            CreateMap<AutorViewModel, Autor>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<Livro, LivroViewModel>();
            CreateMap<Autor, AutorViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}