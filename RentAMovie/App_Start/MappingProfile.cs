using AutoMapper;
using RentAMovie.Dtos;
using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentAMovie.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Movie, MovieDTO>().ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<MovieDTO, Movie>();
        }
    }
}