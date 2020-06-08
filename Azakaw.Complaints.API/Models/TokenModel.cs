using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azakaw.Complaints.API.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public DateTime Expiration { get; set; }

    }
}
