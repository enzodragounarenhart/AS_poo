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
            CreateMap<LivroDTO, Livro>();
            CreateMap<AutorDTO, Autor>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Livro, LivroDTO>();
            CreateMap<Autor, AutorDTO>();
            CreateMap<Usuario, UsuarioDTO>();
        
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