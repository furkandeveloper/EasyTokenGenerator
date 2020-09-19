using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace Jwt.Helpers.Extensions
{
    /// <summary>
    /// This class includes Claim object extensions.
    /// </summary>
    public static class ClaimExtensions
    {
        /// <summary>
        /// Search in claims by claimType
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="claimType"></param>
        /// <returns>
        /// Claim or null.
        /// </returns>
        public static Claim GetClaim(this IEnumerable<Claim> claims, string claimType)
            => claims?.FirstOrDefault(x => x.Type == claimType);

        /// <summary>
        /// Search in claims by claimType.
        /// </summary>
        /// <param name="claims">
        /// Object to search
        /// </param>
        /// <param name="claimType">
        /// Searched type
        /// </param>
        /// <returns>
        /// string or null.
        /// </returns>
        public static string GetClaimValue(this IEnumerable<Claim> claims, string claimType)
            => claims?.FirstOrDefault(x => x.Type == claimType)?.Value;

        /// <summary>
        /// Search in claims by claimType.
        /// </summary>
        /// <param name="claims">
        /// Object to search
        /// </param>
        /// <param name="claimType">
        /// Searched type
        /// </param>
        /// <returns>
        /// Claim list.
        /// </returns>
        public static IEnumerable<Claim> GetClaims(this IEnumerable<Claim> claims, string claimType)
            =>claims?.Where(x => x.Type == claimType);
        /// <summary>
        /// Get email in claims.
        /// </summary>
        /// <param name="claims">
        /// Object to search
        /// </param>
        /// <returns>
        /// string or null
        /// </returns>
        public static string GetEmail(this IEnumerable<Claim> claims)
            => claims.GetClaim(ClaimTypes.Email)?.Value;

        /// <summary>
        /// Get given name in claims.
        /// </summary>
        /// <param name="claims">
        /// Object to search.
        /// </param>
        /// <returns>
        /// string or null.
        /// </returns>
        public static string GetGivenName(this IEnumerable<Claim> claims)
            => claims.GetClaim(ClaimTypes.GivenName)?.Value;

        /// <summary>
        /// Get expiration in claims.
        /// </summary>
        /// <param name="claims">
        /// Object to search
        /// </param>
        /// <returns>
        /// string or null
        /// </returns>
        public static string GetExpiration(this IEnumerable<Claim> claims)
            => claims.GetClaim(ClaimTypes.Expiration)?.Value;
    }
}
