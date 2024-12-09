using IdentityVerificationService.IdentityVerificationRecord.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerification
{
    public interface IIdentityVerificationRepository
    {
        Task<string> VerifyBvnAsync(BvnVerificationDto bvnDto);
    }
}
