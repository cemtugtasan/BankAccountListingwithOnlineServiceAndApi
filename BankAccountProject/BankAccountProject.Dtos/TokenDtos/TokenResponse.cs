using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountProject.Dtos.TokenDtos
{
    public class TokenResponse
    {
        public ResponseData Response { get; set; }
        public Message[] Messages { get; set; }
    }
}
