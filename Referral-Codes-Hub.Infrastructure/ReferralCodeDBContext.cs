using Microsoft.EntityFrameworkCore;
using Referral_Codes_Hub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Infrastructure
{
    public class ReferralCodeDBContext : DbContext
    {
        public ReferralCodeDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ReferralCode> ReferralCodes { get; set; }
    }
}
