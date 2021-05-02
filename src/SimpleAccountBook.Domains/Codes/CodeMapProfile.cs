using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using SimpleAccountBook.Domains.Codes.Models;
using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Domains.Codes
{
    public class CodeMapProfile: Profile
    {
        public CodeMapProfile()
        {
            this.CreateMap<GeneralCode, CodeModel>()
                .ForMember(dest => dest.Codes, src => src.MapFrom(x => x.SubCodes.OrderBy(s => s.Ordinal)));
        }
    }
}
