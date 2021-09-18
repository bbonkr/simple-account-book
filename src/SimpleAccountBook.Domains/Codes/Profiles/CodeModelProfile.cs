using AutoMapper;
using kr.bbon.EntityFrameworkCore.Extensions;
using SimpleAccountBook.Domains.Codes.Models;
using SimpleAccountBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAccountBook.Domains.Codes.Profiles
{
    public class CodeModelProfile :Profile
    {
        public CodeModelProfile()
        {
            CreateMap<GeneralCode, CodeModel>()
                .ForMember(dest => dest.Codes, opt => opt.MapFrom(src => src.SubCodes));

            CreateMap<IPagedModel<CodeModel>, CodesResponseModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<CodeInsertRequestModel, GeneralCode>();
            CreateMap<CodeUpdateRequestModel, GeneralCode>();
        }
    }
}
