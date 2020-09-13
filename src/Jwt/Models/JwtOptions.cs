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
        public string SecurityKey { get; set; } = "mySecurityKey";

        public int LifeTimeMins { get; set; } = 120;
    }
}
