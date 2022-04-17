using Collector.Domain.Interfaces.Repositories;
using Collector.Domain.Interfaces.UnitOfWork;
using Collector.Mappers.ViewModels;

using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Collector.Domain.ViewModels;
using Collector.Domain.Services;

namespace Collector.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _configuration = configuration;

        }

        public async Task<ResponseViewModel<TokenViewModel>> Login(UserViewModel viewModel)
        {
            var user = await _userRepository.GetUser(viewModel.Username, viewModel.Password);
            if (user == null)
            {
                return new FailureResponseDto<TokenViewModel>
                {
                    Data = null,
                    Message = "wrong username or passoword"
                };
            }

            //generate jwt token
            var authClaims = new List<Claim>
                                    {
                                    new Claim(ClaimTypes.Name, user.UserName),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                    };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:SecretKey")));
            var token = new JwtSecurityToken(
            issuer: _configuration.GetValue<string>("JWT:ValidIssuer"),
            audience: _configuration.GetValue<string>("JWT:ValidAudience"),
            expires: DateTime.Now.AddDays(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var issuedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new SuccessResponseDto<TokenViewModel>
            {
                Data = new TokenViewModel
                {
                    Token = issuedToken
                }
            };

        }
    }
}
