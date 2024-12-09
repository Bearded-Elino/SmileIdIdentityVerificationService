using IdentityVerificationService.IdentityVerification;
using IdentityVerificationService.IdentityVerificationRecord.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityVerificationService.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityVerificationController : ControllerBase
    {
        private readonly IIdentityVerificationManager _identityVerificationManager;

        public IdentityVerificationController(IIdentityVerificationManager identityVerificationManager)
        {
            _identityVerificationManager = identityVerificationManager;
        }

        [HttpPost]
        public async Task<IActionResult> VerifyBvn([FromBody] BvnVerificationDto bvnDto)
        {
            try
            {
                if (string.IsNullOrEmpty(bvnDto.id_number))
                {
                    return BadRequest("IdNumber is required.");
                }
                return Ok("verification is successful");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
