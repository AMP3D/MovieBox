using AutoMapper;
using MovieBox.Common.Models;
using MovieBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBox.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieModel, MovieViewModel>();
            CreateMap<MovieCreateModel, MovieModel>();
        }
    }
}