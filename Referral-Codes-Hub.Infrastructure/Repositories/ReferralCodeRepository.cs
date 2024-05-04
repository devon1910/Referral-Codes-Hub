using Azure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Referral_Codes_Hub.Application.Abstractions;
using Referral_Codes_Hub.Application.DTOS;
using Referral_Codes_Hub.Application.Helper;
using Referral_Codes_Hub.Application.ReferralCode.Commands;
using Referral_Codes_Hub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Infrastructure.Repositories
{
    public class ReferralCodeRepository : IReferralCodeRepository
    {
        IdentityDbContext _dbContext;
        ApiResponse<string> response = new ApiResponse<string>();
        public ReferralCodeRepository(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponse<string>> GenerateReferralCodeAndUpdateReferred(CreateReferralCodeUpdateReferred request)
        {
            
            try
            {
                const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                Random random = new();

                int existingReferralCode = await _dbContext.ReferralCodes.Where(x => x.UserId == request.userId).CountAsync();

                if (existingReferralCode > 0)
                {

                    response = new ApiResponse<string>()
                    {
                        status = false,
                        message = "Customer already has a Referral Code.",
                    };
                    return response;
                }

                List<string> referrals = _dbContext.ReferralCodes.Select(x => x.Code).AsNoTracking().ToList();

                string uniqueCode = "";

                while (true)
                {
                    string randomLetters = new string(Enumerable.Repeat(letters, 6)
                   .Select(s => s[random.Next(s.Length)])
                   .ToArray());
                    uniqueCode = randomLetters;
                    if (!referrals.Contains(uniqueCode))
                    {
                        break;
                    }
                }

                string baseUrl = AppSettingsHelper.Settings("BaseUrl");

                ReferralCode referralCodes = new ReferralCode()
                {
                    ReferralLink = baseUrl + uniqueCode,
                    Code = uniqueCode,
                    UserId = request.userId,
                };

                if (request.isReferredFromUser)
                {

                    ReferralCode? customerCode = await _dbContext.ReferralCodes.FirstOrDefaultAsync(x => x.Code == request.referralCode);

                    if (customerCode == null)
                    {
                        response = new ApiResponse<string>()
                        {
                            status = false,
                            message = "Unable to Generate new user Referral Code. Please ensure existing User's Referral Code is valid and try again."
                        };
                        return response;
                    }

                    customerCode.NumberOfUsersReferred += 1;
                    customerCode.DateLastUpdated = DateTime.UtcNow.AddHours(1);
                    referralCodes.ReferredBy = customerCode.UserId;

                }
                await _dbContext.ReferralCodes.AddAsync(referralCodes);
                await _dbContext.SaveChangesAsync();

                response = new ApiResponse<string>()
                {
                    status = true,
                    message = !request.isReferredFromUser ? "Referral Code Generated Successfully" : "Referral Code Generated Successfully and Number of Referrals Updated",
                    data = baseUrl + uniqueCode,
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new ApiResponse<string>()
                {
                    status = false,
                    message = "Unable to Generate Referral Link at the moment, Kindly Reachout to the Technical Team.",

                };
                return response;
            }
        }

        public async Task<ApiResponse<string>> GetCustomerReferralLink(string customerId)
        {
            try
            {
                var referralLink = _dbContext.ReferralCodes.FirstOrDefault(x => x.UserId == customerId);

                response = new ApiResponse<string>()
                {
                    status = true,
                    message = referralLink == null ? "Referral Link for Customer Not Found" : "Referral Link Retrieved.",
                    data = referralLink == null ? "" : referralLink.ReferralLink
                };
                return response;

            }

            catch (Exception ex)
            {
                response = new ApiResponse<string>()
                {
                    status = false,
                    message = "Unable to Retrieve Referral Link at the moment. Kindly reach out to the Technical Team..",
                    data = "",
                };
                return response;
            }
        }


      /*  public ApiResponse<ReferralCode> GetCustomerReferralHistory(string CustomerId)
        {
            ApiResponse<ReferralCode> response1 = new ApiResponse<ReferralCode>();
            try
            {
                var customer = _dbContext.ReferralCodes.FirstOrDefault(x => x.UserId == CustomerId);

                if (customer == null)
                {
                    response1 = new ApiResponse<ReferralCode>()
                    {
                        status = true,
                        message = "User not Found",
                    };
                    return response1;
                }

                response1 = new ApiResponse<ReferralCode>()
                {
                    status = true,
                    message = "Customer Referral History Retrieved.",
                    data = customer
                };
                return response1;

            }
            catch (Exception ex)
            {
                response1 = new ApiResponse<ReferralCode>()
                {
                    status = false,
                    message = "Unable to retrieve Customer Referral History at the moment. Kindly reach out to the Technical Team..",
                };
                return response1;
            }
        }*/

    }
}
