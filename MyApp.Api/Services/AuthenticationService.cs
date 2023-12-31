﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MyApp.Api.IServices;
using MyApp.Shared.ViewModel;
using MyApp.Shared.Models;

namespace MyApp.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ICartService _cartService;

        public AuthenticationService(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, IConfiguration configuration, ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _cartService = cartService;
        }
        private async Task<string> GenerateJwtTokenAsync(UserModel user)
        {
            var role = await _userManager.GetRolesAsync(user);
            // Create list of claims
            var claims = new List<Claim>()
            {
                    new Claim(ClaimTypes.Name,user.UserName.ToString()),
                    new Claim(ClaimTypes.Role,role.FirstOrDefault()),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Email,user.Email.ToString()),
            };

            // Create JWT Token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["JWT:Issuer"], _configuration["JWT:Audience"], claims,
                expires: DateTime.UtcNow.AddDays(7), signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<Response> Login(LoginViewModel model)
        {
            var response = new Response();
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                response.StatusCode = 400;
                response.Messages = "User not exist";
                return response;
            }
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                response.StatusCode = 400;
                response.Messages = "Password is fail";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false); // login
            if (result.Succeeded)
            {
                response.IsSuccess = true;
                response.StatusCode = 200;
                response.Messages = "Login success";
                response.Token = await GenerateJwtTokenAsync(user);
                return response;
            }
            else
            {
                response.StatusCode = 500;
                response.Messages = "Login fail";
                return response;
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<Response> Register(RegisterViewModel model)
        {
            var response = new Response();
            var userExist = await _userManager.FindByNameAsync(model.UserName);
            var emailExist = await _userManager.FindByEmailAsync(model.Email);
            if (userExist != null)
            {
                response.StatusCode = 400;
                response.Messages = "User already exist";
                return response;
            }
            else if (emailExist != null)
            {
                response.StatusCode = 400;
                response.Messages = "Email already exist";
                return response;
            }
            if (model.Password != model.PasswordConfirm)
            {
                response.StatusCode = 400;
                response.Messages = "This password doesn't match with confirm password!";
                return response;
            }
            // new rank 
            UserModel identityUser = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                FullName = model.FullName,
                ProfilePictureUrl = "",
                Points = 0,
            };
            var result = await _userManager.CreateAsync(identityUser, model.Password); // create user


            if (!result.Succeeded)
            {
                response.StatusCode = 400;
                response.Messages = "SignUp failed!";
                return response;
            }
            var cart = new CartModel()
            {
                UserId = identityUser.Id
            };
            _cartService.AddItem(cart); // create cart
            await _userManager.AddToRoleAsync(identityUser, "User");
            response.StatusCode = 200;
            response.Messages = "Sign Up Successfully!";
            return response;
        }
    }
}
