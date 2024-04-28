using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referral_Codes_Hub.Application.DTOS
{
    public class ApiResponse<T>
    {
        public bool status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
    public class ApiResponseFailed<T>
    {
        /// <summary>
        /// Gets or sets the status of the response.
        /// </summary>
        [DefaultValue(false)]
        public bool status { get; set; }
        public string message { get; set; }
        public T data { get; set; }

    }

}
