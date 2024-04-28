using MediatR;
using Microsoft.AspNetCore.Mvc;
using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.ReferralCode.Commands;
using Referral_Codes_Hub.Application.ReferralCode.Queries;

namespace Referral_Codes_Hub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferralCodeController
    {
        private readonly IMediator mediator;
        public ReferralCodeController(IMediator _mediator)
        {
            mediator = _mediator;
        }
      
        [HttpPost("[action]")]
        public async Task<ApiResponse<string>> GenerateReferralLink([FromBody] CreateReferralCodeUpdateReferred createReferralCodeUpdateReferred) => await this.mediator.Send(createReferralCodeUpdateReferred);

        [HttpGet("[action]")]
        public async Task<ApiResponse<string>> GetUserReferralLink(GetUserReferralLink getUserReferralLink) => await this.mediator.Send(getUserReferralLink);


    }
}
