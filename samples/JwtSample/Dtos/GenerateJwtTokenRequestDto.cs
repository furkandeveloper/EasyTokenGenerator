using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtSample.Dtos
{
    public class GenerateJwtTokenRequestDto
    {
        public string Email { get; set; } = "string@string.com";

        public string Password { get; set; } = "123456";
    }
}
