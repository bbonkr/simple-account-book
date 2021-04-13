
using AutoMapper;

using SimpleAccountBook.Entities;

namespace SimepleAccountBook.App.Domains.Codes
{
    public class GeneralCodeToModelMapProfile : Profile
    {
        public GeneralCodeToModelMapProfile()
        {
            CreateMap<GeneralCode, CodeModel>();
        }
    }
}
