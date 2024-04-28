using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Domain.Entities
{
    public sealed class ReferralCode
    {
        [Key]
        public int RefId { get; set; }
        public required string UserId { get; set; }
        public required string Code { get; set; }
        public required string ReferralLink { get; set; }
        public int NumberOfUsersReferred { get; set; } = 0;
        public string? ReferredBy { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow.AddHours(1);
    }
}
