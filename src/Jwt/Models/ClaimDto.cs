using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Models
{
    /// <summary>
    /// This object use for claim generator.
    /// </summary>
    public class ClaimDto
    {
        /// <summary>
        /// Claim type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Claim value
        /// </summary>
        public string Value { get; set; }
    }
}
