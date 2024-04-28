using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.ReferralCode.Commands;
using Referral_Codes_Hub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.Abstractions
{
    public interface IReferralCodeRepository
    {
        Task<ApiResponse<string>> GenerateReferralCodeAndUpdateReferred(CreateReferralCodeUpdateReferred req);
        Task<ApiResponse<string>> GetCustomerReferralLink(string CustomerId);
        //ReferralCode GetCustomerReferralHistory(string CustomerId);
    }
}
