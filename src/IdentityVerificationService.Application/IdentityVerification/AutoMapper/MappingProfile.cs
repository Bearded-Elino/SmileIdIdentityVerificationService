using AutoMapper;
using IdentityVerificationService.IdentityVerificationRecord;
using IdentityVerificationService.IdentityVerificationRecord.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerification.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BvnVerificationRequest, BvnVerificationDto>().ReverseMap();
        }
    }
}
