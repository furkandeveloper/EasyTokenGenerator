using System;
using System.Collections.Generic;
using System.Text;

namespace Jwt.Models
{
    /// <summary>
    /// Includes Security Algorithms.
    /// </summary>
    public enum Algorithms
    {
        /// <summary>
        /// HS256
        /// </summary>
        HmacSha256Signature,
        /// <summary>
        /// HS384
        /// </summary>
        HmacSha384,
        /// <summary>
        /// HS512
        /// </summary>
        HmacSha512,
        /// <summary>
        /// RS256
        /// </summary>
        RsaSha256Signature,
        /// <summary>
        /// RS384
        /// </summary>
        RsaSha384Signature,
        /// <summary>
        /// RS512
        /// </summary>
        RsaSha512Signature,
        /// <summary>
        /// ES256
        /// </summary>
        EcdsaSha256,
        /// <summary>
        /// ES384
        /// </summary>
        EcdsaSha384,
        /// <summary>
        /// ES512
        /// </summary>
        EcdsaSha512,
        /// <summary>
        /// PS256
        /// </summary>
        RsaSsaPssSha256,
        /// <summary>
        /// PS384
        /// </summary>
        RsaSsaPssSha384
    }
}
