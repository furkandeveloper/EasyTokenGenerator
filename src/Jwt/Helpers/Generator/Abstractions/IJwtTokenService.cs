using Jwt.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Helpers.Generator.Abstractions
{
    public interface IJwtTokenService
    {
        Task<string> GenerateJwtTokenAsync();
        Task<string> GenerateJwtTokenAsync(Claim[] claims, Algorithms algorithms);
    }
}
