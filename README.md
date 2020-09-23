<p align="center">
  <img src="https://user-images.githubusercontent.com/47147484/93689794-a669fd80-fada-11ea-92e9-8693d0ae9c50.png" />
</p>

# Token Generator for .Net
[![CodeFactor](https://www.codefactor.io/repository/github/furkandeveloper/easytokengenerator/badge)](https://www.codefactor.io/repository/github/furkandeveloper/easytokengenerator)
![.NET Core](https://github.com/furkandeveloper/EasyTokenGenerator/workflows/.NET%20Core/badge.svg?branch=master)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![CircleCI](https://circleci.com/gh/furkandeveloper/EasyTokenGenerator.svg?style=svg)](https://circleci.com/gh/circleci/circleci-docs)

Heeey, This repo aims to dynamically and simply generate tokens in Token Based systems. 
Follow me;
  - Turn on your computer.
  - Prepare your coffee.
  - And sit back.

# What is Authentication?

 Authentication is the set of processes that try to recognize the user on the system with information such as User Name, Password, Email or Phone Number.
 
## Single Factor Authentication

This method, which we use quite often in daily life, will be sufficient for the user to enter the password corresponding to any information in order to navigate in the system.

## Two Factor Authentication
With this method, a more secure authentication is achieved by requesting another information that can only be accessed by the user in addition to User Name and Password information. An example is the confirmation code that is used in daily life in banks and comes as an SMS after login.


# What is Token Based Authentication?

A token is a piece of data that has no meaning or use on its own, but combined with the correct tokenization system, becomes a vital player in securing your application. Token based authentication works by ensuring that each request to a server is accompanied by a signed token which the server verifies for authenticity and only then responds to the request.

JSON Web Token (JWT) is an open standard (RFC 7519) that defines a compact and self-contained method for securely transmitting information between parties encoded as a JSON object. JWT has gained mass popularity due to its compact size which allows tokens to be easily transmitted via query strings, header attributes and within the body of a POST request.

## Getting Started

Install [EasyTokenGenerator](https://www.nuget.org/packages/EasyJwtTokenGenerator/) from Nuget.

# Startup.cs Configuration

```csharp
services.AddEasyJwtToken(options =>
{
      Configuration.Bind(nameof(JwtBearerOptions), options);
      options.SecurityKey = Configuration.GetValue<string>("SecurityKey");
});
```

## Usage
Get the IJwtTokenGenerator interface from the Constructor.

```csharp
private readonly IJwtTokenService jwtTokenService;

public AccountController(IJwtTokenService jwtTokenService)
{
      this.jwtTokenService = jwtTokenService;
}
```
# Generate Claims
```csharp
var claims = await jwtTokenService.GenerateClaimsAsync(new List<Jwt.Models.ClaimDto>()
{
    new Jwt.Models.ClaimDto()
    {
        Type = "Email",
        Value = "string@string.com"
    }
});
```

# Generate Jwt Token
```csharp
var jwtToken = await jwtTokenService.GenerateJwtTokenAsync(claims, Jwt.Models.Algorithms.HmacSha256Signature);
```
Easy Token Generator supported Security Algorithms. Look. 
```csharp
public enum Algorithms
{
    HmacSha256Signature,
    HmacSha384,
    HmacSha512,
    RsaSha256Signature,
    RsaSha384Signature,
    RsaSha512Signature,
    EcdsaSha256,
    EcdsaSha384,
    EcdsaSha512,
    RsaSsaPssSha256,
    RsaSsaPssSha384
}
```
# Generate Refresh Token

```csharp
await jwtTokenService.GenerateRefreshTokenAsync(size:64)
```

## Extensions

# Claims Extensions

```csharp
public static Claim GetClaim(this IEnumerable<Claim> claims, string claimType)
            => claims?.FirstOrDefault(x => x.Type == claimType);
// Usage
var claim = User.Claims.GetClaim("Email");
```

```csharp
public static string GetClaimValue(this IEnumerable<Claim> claims, string claimType)
            => claims?.FirstOrDefault(x => x.Type == claimType)?.Value;
// Usage
var claimValue = User.Claims.GetClaimValue("Email");
```

```csharp
public static IEnumerable<Claim> GetClaims(this IEnumerable<Claim> claims, string claimType)
            =>claims?.Where(x => x.Type == claimType);
// Usage
var claims = User.Claims.GetClaims("Email");
```

```csharp
public static string GetEmail(this IEnumerable<Claim> claims)
            => claims.GetClaim(ClaimTypes.Email)?.Value;
// Usage
var email = User.Claims.GetEmail();
```


```csharp
public static string GetGivenName(this IEnumerable<Claim> claims)
            => claims.GetClaim(ClaimTypes.GivenName)?.Value;
// Usage
var givenName = User.Claims.GetGivenName();
```


```csharp
public static string GetExpiration(this IEnumerable<Claim> claims)
            => claims.GetClaim(ClaimTypes.Expiration)?.Value;
// Usage
var expiration = User.Claims.GetExpiration();
```

You can look at the [demo](https://easy-token-generator.herokuapp.com/)
