using AutoMapper;
using GameGale.Dtos;
using GameGale.Models;

namespace GameGale.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Game, GameDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            //Dto to Domain
            //UpdateCustomer throws the exception:
            //"The property 'Id' is part of the object's key information and cannot be modified."
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<GameDto, Game>()
                .ForMember(g => g.Id, opt => opt.Ignore());
        }
    }
}