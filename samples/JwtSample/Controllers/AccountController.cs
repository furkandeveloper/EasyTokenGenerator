using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jwt.Helpers.Generator.Abstractions;
using JwtSample.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;

namespace JwtSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiVersion("1.0")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtTokenService jwtTokenService;

        public AccountController(IJwtTokenService jwtTokenService)
        {
            this.jwtTokenService = jwtTokenService;
        }

        [HttpPost(Name ="GenerateJwtToken")]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateJwtTokenAsync([FromBody] GenerateJwtTokenRequestDto model)
        {
            var claims = await jwtTokenService.GenerateClaimsAsync(new List<Jwt.Models.ClaimDto>()
            {
                new Jwt.Models.ClaimDto()
                {
                    Type = "Email",
                    Value = model.Email.Trim()
                }
            });
            var jwtToken = await jwtTokenService.GenerateJwtTokenAsync(claims, Jwt.Models.Algorithms.HmacSha256Signature);
            return Ok(jwtToken);
        }

        [HttpGet(Name ="GetBooks")]
        public async Task<IActionResult> GetBooksAsync()
        {
            return Ok(new string[] { "Book1", "Book" });
        }
    }
}
