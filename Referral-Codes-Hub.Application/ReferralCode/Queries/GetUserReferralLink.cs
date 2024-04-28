using MediatR;
using Referral_Codes_Hub.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.ReferralCode.Queries
{
    public class GetUserReferralLink : IRequest<ApiResponse<string>>
    {
        public required string UserId { get; set; }
    }
}
