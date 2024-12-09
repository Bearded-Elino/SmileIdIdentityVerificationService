using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerificationRecord
{
    public class BvnVerificationResult
    {
        public string Bvn { get; set; }
        public bool IsVerified { get; set; }
        public string VerificationMessage { get; set; }
    }
}
