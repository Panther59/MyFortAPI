// <copyright file="OutletsController.cs" company="Ayvan">
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
	/// Defines the <see cref="OutletsController" />
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class OutletsController : ControllerBase
	{
		/// <summary>
		/// Defines the configuration
		/// </summary>
		private readonly IConfiguration configuration;

		/// <summary>
		/// Defines the encryptionHelper
		/// </summary>
		private readonly IEncryptionHelper encryptionHelper;
		private readonly IOutletService outletService;

		/// <summary>
		/// Defines the session
		/// </summary>
		private readonly ISession session;

		/// <summary>
		/// Initializes a new instance of the <see cref="OutletsController"/> class.
		/// </summary>
		/// <param name="session">The session<see cref="ISession"/></param>
		/// <param name="encryptionHelper">The encryptionHelper<see cref="IEncryptionHelper"/></param>
		/// <param name="OutletsService">The OutletsService<see cref="IOutletsService"/></param>
		/// <param name="configuration">The configuration<see cref="IConfiguration"/></param>
		public OutletsController(
			ISession session,
			IEncryptionHelper encryptionHelper,
			IOutletService outletService,
			IConfiguration configuration)
		{
			this.session = session;
			this.encryptionHelper = encryptionHelper;
			this.outletService = outletService;
			this.configuration = configuration;
		}

		/// <summary>
		/// The Get
		/// </summary>
		/// <returns>The <see cref="Task{List{Outlet}}"/></returns>
		[HttpGet]
		[Authorize]
		public async Task<List<Outlet>> Get()
		{
			return await this.outletService.GetAllOutlets();
		}


		/// <summary>
		/// The Register
		/// </summary>
		/// <param name="Outlet">The Outlet<see cref="RegisterOutlet"/></param>
		/// <returns>The <see cref="Task{Outlet}"/></returns>
		[HttpPost("new")]
		[Authorize]
		public async Task NewOutlet(Outlet outlet)
		{
			await this.outletService.AddOutlet(outlet);
		}

		/// <summary>
		/// The Update
		/// </summary>
		/// <param name="outlet">The Outlet<see cref="Outlet"/></param>
		/// <returns>The <see cref="Task{Outlet}"/></returns>
		[HttpPost("update")]
		[Authorize]
		public async Task Update(Outlet outlet)
		{
			await this.outletService.UpdateOutlet(outlet);
		}
	}
}