using AutoMapper;
using BankAccountProject.Dtos;
using BankAccountProject.Entities;

namespace BankAccountProject.Services
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BankAccountDto, BankAccount>().ReverseMap();           
        }
    }
}