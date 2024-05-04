using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.ReferralCode.Commands;
using Referral_Codes_Hub.Application.ReferralCode.Queries;

namespace Referral_Codes_Hub.API.Controllers
{
    [Authorize]
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

        [HttpGet("[action]/{UserID}")]
        public async Task<ApiResponse<string>> GetUserReferralLink( string UserID) => await this.mediator.Send(new GetUserReferralLink {UserId= UserID });


    }
}
