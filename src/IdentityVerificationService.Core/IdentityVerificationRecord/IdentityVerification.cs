using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityVerificationService.IdentityVerificationRecord
{
    public class IdentityVerification : FullAuditedEntity<Guid>
    {
        public int Id { get; set; }
        public string BusinessType { get; set; }
        public string CallbackUrl { get; set; }
        public string Country { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public string PartnerId { get; set; }
        public string JobType { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
