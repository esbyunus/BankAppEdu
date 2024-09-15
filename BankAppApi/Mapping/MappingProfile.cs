using AutoMapper;
using BankAppApi.Dto;
using BankAppApi.Entities;

namespace BankAppApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<AccountApplication, AccountApplicationDto>().ReverseMap();
            CreateMap<TransactionMoney, TransactionMoneyDto>().ReverseMap();

        }
    }
}
