using Abp.Application.Services;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdentityVerificationService.IdentityVerificationRecord;
using IdentityVerificationService.IdentityVerificationRecord.Dtos;
using System.Threading.Tasks;
using IdentityVerificationService.Application.Shared;
using System;
using Microsoft.AspNetCore.Authorization;

namespace IdentityVerificationService.IdentityVerification
{
    //[AbpAuthorize] // Optional: Specify required permissions
    [Route("api/v1/IdentityVerification")]
    public class IdentityVerificationAppService : ApplicationService
    {
        private readonly IIdentityVerificationManager _identityVerificationManager;

        
        public IdentityVerificationAppService(IIdentityVerificationManager identityVerificationManager)
        {
            _identityVerificationManager = identityVerificationManager;
        }

        [HttpPost("VerifyBvn")]
        [AllowAnonymous]
        public async Task<OResponse<string>> VerifyBvnAsync(BvnVerificationRequest input)
        {
            try
            {
                var verificationResult = await _identityVerificationManager.VerifyBvnAsync(input);
                return new OResponse<string>
                {
                    ResultCode = 0, // Success code
                    ResultDescription = "BVN verification successful",
                    Data = verificationResult
                };
            }
            catch (Exception ex)
            {
                // Log the exception
                Logger.Error("BVN verification failed", ex);
                return new OResponse<string>
                {
                    ResultCode = 1, // Error code
                    ResultDescription = "BVN verification failed: " + ex.Message
                };
            }
        }
    }
}
