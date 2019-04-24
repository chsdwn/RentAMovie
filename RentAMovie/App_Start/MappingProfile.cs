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
            // Domain to DTO
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<MembershipType, MembershipTypeDTO>();

            // DTO to Domain
            CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<MovieDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}