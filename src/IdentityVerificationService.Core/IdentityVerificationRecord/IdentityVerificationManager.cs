using System.Threading.Tasks;
using IdentityVerificationService.Services; // For SmileIdService
using IdentityVerificationService.IdentityVerificationRecord.Dtos;
using AutoMapper;
using IdentityVerificationService.IdentityVerificationRecord;

namespace IdentityVerificationService.IdentityVerification
{
    public class IdentityVerificationManager : IIdentityVerificationManager
    {
        private readonly SmileIdService _smileIdService;
        private readonly IMapper _mapper;

        public IdentityVerificationManager(SmileIdService smileIdService, IMapper mapper)
        {
            _smileIdService = smileIdService;
            _mapper = mapper;
        }

        public async Task<string> VerifyBvnAsync(BvnVerificationRequest bvnRequest)
        {
            // Use AutoMapper to map to DTO
            var bvnDto = _mapper.Map<BvnVerificationDto>(bvnRequest);

            return await _smileIdService.VerifyBvnAsync(bvnDto);
        }
    }
}
