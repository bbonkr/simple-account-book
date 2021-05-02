
using AutoMapper;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.App.Domains.Codes
{
    public class GeneralCodeToModelMapProfile : Profile
    {
        public GeneralCodeToModelMapProfile()
        {
            CreateMap<GeneralCode, CodeModel>();
        }
    }
}
