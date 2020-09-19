using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Models
{
    /// <summary>
    /// This class includes jwt bearer options.
    /// </summary>
    public class JwtOptions : JwtBearerOptions
    {
        /// <summary>
        /// This parameter get value "mySecurityKey" when null value.
        /// </summary>
        public string SecurityKey { get; set; } = "mySecurityKey";

        /// <summary>
        /// This parameter get value 120 when null value.
        /// </summary>
        public int LifeTimeMins { get; set; } = 120;
    }
}
