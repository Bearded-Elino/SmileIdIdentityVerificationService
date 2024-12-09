using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.Configuration
{
    public class SmileIdConfig
    {
        public string PartnerId { get; set; }
        public string SecretKey { get; set; }
        public string BaseUrl { get; set; }
    }
}
