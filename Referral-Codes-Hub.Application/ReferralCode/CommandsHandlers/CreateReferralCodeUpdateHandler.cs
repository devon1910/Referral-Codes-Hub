using MediatR;
using Referral_Codes_Hub.Application.Abstractions;
using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.ReferralCode.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.ReferralCode.CommandsHandlers
{
    public class CreateReferralCodeUpdateHandler : IRequestHandler<CreateReferralCodeUpdateReferred, ApiResponse<string>>
    {

        private readonly IReferralCodeRepository _referralCodeRepository;
        ApiResponse<string> response;
        public CreateReferralCodeUpdateHandler(IReferralCodeRepository referralCodeRepository)
        {
            _referralCodeRepository = referralCodeRepository;
        }

        public async Task<ApiResponse<string>> Handle(CreateReferralCodeUpdateReferred request, CancellationToken cancellationToken)
        {
            return await _referralCodeRepository.GenerateReferralCodeAndUpdateReferred(request);
           
        }
    }
}
