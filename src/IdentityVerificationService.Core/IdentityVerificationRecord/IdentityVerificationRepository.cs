using IdentityVerificationService.IdentityVerificationRecord.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerification
{
    public class IdentityVerificationRepository : IIdentityVerificationRepository
    {
        public async Task<string> VerifyBvnAsync(BvnVerificationDto bvnDto)
        {
            return await Task.FromResult("Verification Result");
        }
    }
}
