using Referral_Codes_Hub.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Infrastructure
{
    public static class CreateAPIResponse<T>
    {
        public static ApiResponse<T> GenerateResponse(bool status, string message, T data)
        {
            return new ApiResponse<T>() {data=data,status=status,message=message };
        }
    }
}
