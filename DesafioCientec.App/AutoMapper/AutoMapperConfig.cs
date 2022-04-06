using AutoMapper;
using DesafioCientec.App.ViewModels;
using DesafioCientec.Business.Models;

namespace DesafioCientec.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fundacao, FundacaoViewModel>().ReverseMap();
        }
    }
}
