using Jwt.Helpers.Generator.Abstractions;
using Jwt.Helpers.Generator.Concrete;
using Jwt.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Jwt.Services
{
    /// <summary>
    /// This class includes options for Jwt Token Generator.
    /// </summary>
    public static class ServiceCollection
    {
        /// <summary>
        /// Extensions method for service collection object in startup.cs
        /// </summary>
        /// <param name="services">
        /// Service collection object
        /// </param>
        /// <param name="options">
        /// Default JwtBearerOptions object
        /// </param>
        /// <returns>
        /// Service collection
        /// </returns>
        public static IServiceCollection AddEasyJwtToken(this IServiceCollection services,Action<JwtOptions> options)
        {
            JwtOptions jwtOptions = new JwtOptions();
            options.Invoke(jwtOptions);
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opt =>
                {
                    opt = jwtOptions;
                    opt.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey));
                });
            services.AddSingleton(jwtOptions);
            services.AddTransient<IJwtTokenService, JwtTokenManager>();
            return services;
        }
    }
}
