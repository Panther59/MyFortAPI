// <copyright file="VisitsController.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-02-28</date>

namespace MyFortAPI.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using MyFortAPI.Common;
	using MyFortAPI.Models;
	using MyFortAPI.Services;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using ISession = Common.ISession;

	/// <summary>
	/// Defines the <see cref="VisitsController" />
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class VisitsController : ControllerBase
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
		/// Defines the visitService
		/// </summary>
		private readonly IVisitsService visitService;

		/// <summary>
		/// Initializes a new instance of the <see cref="VisitsController"/> class.
		/// </summary>
		/// <param name="session">The session<see cref="ISession"/></param>
		/// <param name="encryptionHelper">The encryptionHelper<see cref="IEncryptionHelper"/></param>
		/// <param name="visitService">The visitService<see cref="IVisitsService"/></param>
		/// <param name="configuration">The configuration<see cref="IConfiguration"/></param>
		public VisitsController(
			ISession session,
			IEncryptionHelper encryptionHelper,
			IVisitsService visitService,
			IConfiguration configuration)
		{
			this.session = session;
			this.encryptionHelper = encryptionHelper;
			this.visitService = visitService;
			this.configuration = configuration;
		}

		/// <summary>
		/// The Get
		/// </summary>
		/// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
		/// <returns>The <see cref="Task{List{Visit}}"/></returns>
		[HttpPost]
		[Authorize]
		public async Task<List<Visit>> GetAll([FromBody]DateTime dateTime)
		{
			return await this.visitService.GetAllTodaysVisits(dateTime);
		}

		/// <summary>
		/// The GetAllMine
		/// </summary>
		/// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
		/// <returns>The <see cref="Task{List{Visit}}"/></returns>
		[HttpPost("mine")]
		[Authorize]
		public async Task<List<Visit>> GetAllMine([FromBody]DateTime dateTime)
		{
			return await this.visitService.GetAllMyVisits(dateTime);
		}

		/// <summary>
		/// The NewVisit
		/// </summary>
		/// <param name="Visit">The Visit<see cref="Visit"/></param>
		/// <returns>The <see cref="Task"/></returns>
		[HttpPost("new")]
		[Authorize]
		public async Task NewVisit(Visit Visit)
		{
			await this.visitService.AddVisit(Visit);
		}
	}
}
