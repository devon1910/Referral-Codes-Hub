using MediatR;
using Referral_Codes_Hub.Application.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.ReferralCode.Commands
{
    public class CreateReferralCodeUpdateReferred : IRequest<ApiResponse<string>>
    {
        public required string userId { get; set; }

        public string? referralCode { get; set; }
        [DefaultValue(false)]
        public bool isReferredFromUser { get; set; }
    }
}
