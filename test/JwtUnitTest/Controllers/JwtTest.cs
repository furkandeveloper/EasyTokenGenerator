using FluentAssertions;
using Jwt.Helpers.Generator.Abstractions;
using Jwt.Models;
using JwtSample.Controllers;
using JwtSample.Dtos;
using JwtUnitTest.Statics;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JwtUnitTest.Controllers
{
    public class JwtTest
    {
        [Theory,AutoMoqData]
        public async Task GenerateJwtTokenAsync_Return_Ok_Result(Mock<IJwtTokenService> jwtTokenService,
                                                                string expected)
        {
            // Arrange
            var sut = new AccountController(jwtTokenService.Object);
            var requestDto = new GenerateJwtTokenRequestDto() { Email = "string@string.com", Password = "123456" };
            jwtTokenService.Setup(setup => setup.GenerateJwtTokenAsync()).Returns(Task.FromResult(expected));

            // Act
            var result = sut.GenerateJwtTokenAsync(requestDto);
            var apiResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var model = apiResult.Value;

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsNotType<CreatedAtActionResult>(result.Result);
            Assert.IsNotType<BadRequestObjectResult>(result.Result);
            Assert.IsNotType<AcceptedAtActionResult>(result.Result);

            Assert.NotNull(result.Result);
            Assert.NotNull(expected);
        }

        [Theory, AutoMoqData]
        public async Task GenerateRefreshToken_Return_Ok_Result(Mock<IJwtTokenService> jwtTokenService,
                                                                string expected)
        {
            // Arrange
            var sut = new AccountController(jwtTokenService.Object);
            int size = 64;
            jwtTokenService.Setup(setup => setup.GenerateRefreshTokenAsync(size)).Returns(Task.FromResult(expected));

            // Act
            var result = sut.GenerateRefreshTokenAsync(size);
            var apiResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var model = apiResult.Value;

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsNotType<CreatedAtActionResult>(result.Result);
            Assert.IsNotType<BadRequestObjectResult>(result.Result);
            Assert.IsNotType<AcceptedAtActionResult>(result.Result);

            Assert.NotNull(result.Result);
            Assert.NotNull(expected);
        }
    }
}
