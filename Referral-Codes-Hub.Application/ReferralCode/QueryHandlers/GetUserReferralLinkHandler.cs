using MediatR;
using Referral_Codes_Hub.Application.Abstractions;
using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.ReferralCode.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.ReferralCode.QueryHandlers
{
    public class GetUserReferralLinkHandler : IRequestHandler<GetUserReferralLink, ApiResponse<string>>
    {
        private readonly IReferralCodeRepository _referralCodeRepository;
        ApiResponse<string> response;
        public GetUserReferralLinkHandler(IReferralCodeRepository referralCodeRepository)
        {
            _referralCodeRepository = referralCodeRepository;
        }

        public async Task<ApiResponse<string>> Handle(GetUserReferralLink request, CancellationToken cancellationToken)
        {
            return await _referralCodeRepository.GetCustomerReferralLink(request.UserId);
        }
    }
}
