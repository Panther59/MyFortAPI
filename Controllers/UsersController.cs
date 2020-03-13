// <copyright file="UsersController.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-02-28</date>

namespace MyFortAPI.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using Microsoft.IdentityModel.Tokens;
	using MyFortAPI.Common;
	using MyFortAPI.Filters;
	using MyFortAPI.Models;
	using MyFortAPI.Services;
	using System;
	using System.Collections.Generic;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using System.Text;
	using System.Threading.Tasks;
	using ISession = Common.ISession;

	/// <summary>
	/// Defines the <see cref="UsersController" />
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		/// <summary>
		/// Defines the configuration
		/// </summary>
		private readonly IConfiguration configuration;

		/// <summary>
		/// Defines the encryptionHelper
		/// </summary>
		private readonly IEncryptionHelper encryptionHelper;

		/// <summary>
		/// Defines the session
		/// </summary>
		private readonly ISession session;

		/// <summary>
		/// Defines the usersService
		/// </summary>
		private readonly IUsersService usersService;

		/// <summary>
		/// Initializes a new instance of the <see cref="UsersController"/> class.
		/// </summary>
		/// <param name="session">The session<see cref="ISession"/></param>
		/// <param name="encryptionHelper">The encryptionHelper<see cref="IEncryptionHelper"/></param>
		/// <param name="usersService">The usersService<see cref="IUsersService"/></param>
		/// <param name="configuration">The configuration<see cref="IConfiguration"/></param>
		public UsersController(
			ISession session,
			IEncryptionHelper encryptionHelper,
			IUsersService usersService,
			IConfiguration configuration)
		{
			this.session = session;
			this.encryptionHelper = encryptionHelper;
			this.usersService = usersService;
			this.configuration = configuration;
		}

		/// <summary>
		/// The Authenticate
		/// </summary>
		/// <param name="request">The request<see cref="AuthenticateRequest"/></param>
		/// <returns>The <see cref="Task{AuthenticateResponse}"/></returns>
		[HttpPost("authenticate")]
		[AllowAnonymous]
		public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
		{
			if (request != null)
			{
				var user = await this.usersService.Authenticate(request.Email, request.Password);

				if (user == null)
				{
					throw new UnauthorizedAccessException();
				}

				var token = this.GenerateJSONWebToken(user);
				var response = new AuthenticateResponse
				{
					Token = token,
					User = user
				};

				return response;
			}
			else
			{
				//Handle what happens if that isn't the case
				throw new UnauthorizedAccessException();
			}
		}

		/// <summary>
		/// The Get
		/// </summary>
		/// <returns>The <see cref="Task{List{User}}"/></returns>
		[HttpGet]
		[UserTypeFilter(ClaimTypes.Role, TypeOfUser.Admin | TypeOfUser.ITAdmin | TypeOfUser.Supervisor)]
		public async Task<List<User>> Get()
		{
			return await this.usersService.GetUsers();
		}

		/// <summary>
		/// The GetCurrentUser
		/// </summary>
		/// <returns>The <see cref="Task{User}"/></returns>
		[HttpGet("current")]
		public async Task<User> GetCurrentUser()
		{
			var userId = this.session.UserID;
			if (userId.HasValue)
			{
				return await this.usersService.GetUser(userId.Value);
			}
			else
			{
				throw new UnauthorizedAccessException("User toekn is missing.");
			}
		}

		/// <summary>
		/// The Register
		/// </summary>
		/// <param name="user">The user<see cref="RegisterUser"/></param>
		/// <returns>The <see cref="Task{User}"/></returns>
		[HttpPost("register")]
		[AllowAnonymous]
		public async Task<User> Register(RegisterUser user)
		{
			return await this.usersService.RegisterUser(user);
		}

		/// <summary>
		/// The Update
		/// </summary>
		/// <param name="user">The user<see cref="User"/></param>
		/// <returns>The <see cref="Task{User}"/></returns>
		[HttpPost("update")]
		[UserTypeFilter(ClaimTypes.Role, TypeOfUser.Admin | TypeOfUser.ITAdmin | TypeOfUser.Supervisor)]
		public async Task<User> Update(User user)
		{
			return await this.usersService.UpdateUser(user);
		}

		/// <summary>
		/// The GenerateJSONWebToken
		/// </summary>
		/// <param name="user">The user<see cref="User"/></param>
		/// <returns>The <see cref="string"/></returns>
		private string GenerateJSONWebToken(User user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[] {
						new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
						new Claim(ClaimTypes.Email, user.Email),
						new Claim(ClaimTypes.Role, user.Type.ToString()),
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())};

			var token = new JwtSecurityToken(
				this.configuration["Jwt:Issuer"],
				this.configuration["Jwt:Issuer"],
				claims,
				expires: DateTime.Now.AddMinutes(120),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
