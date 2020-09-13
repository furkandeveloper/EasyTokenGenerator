using Jwt.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Helpers.Generator.Abstractions
{
    /// <summary>
    /// This interface includes functions for jwt token generator.
    /// </summary>
    public interface IJwtTokenService
    {
        /// <summary>
        /// Without parameter Jwt Token Generator.
        /// </summary>
        /// <returns>
        /// Jwt Token
        /// </returns>
        Task<string> GenerateJwtTokenAsync();
        /// <summary>
        /// Jwt token generator with claims and security algorithm.
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="algorithms"></param>
        /// <returns>
        /// Jwt Token
        /// </returns>
        Task<string> GenerateJwtTokenAsync(Claim[] claims, Algorithms algorithms);

        /// <summary>
        /// Generate claims
        /// </summary>
        /// <param name="claimDto"></param>
        /// <returns>
        /// Claims
        /// </returns>
        Task<Claim[]> GenerateClaimsAsync(List<ClaimDto> claimDto);

        /// <summary>
        /// Generate refresh token
        /// </summary>
        /// <param name="size"></param>
        /// <returns>
        /// Refresh Token
        /// </returns>
        Task<string> GenerateRefreshTokenAsync(int size = 64);
    }
}
