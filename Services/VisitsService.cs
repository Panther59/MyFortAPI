// <copyright file="VisitsService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-14</date>

namespace MyFortAPI.Services
{
	using Microsoft.EntityFrameworkCore;
	using MyFortAPI.Common;
	using MyFortAPI.Data;
	using MyFortAPI.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="VisitsService" />
	/// </summary>
	public class VisitsService : IVisitsService
	{
		/// <summary>
		/// Defines the mapper
		/// </summary>
		private readonly IMapper mapper;

		/// <summary>
		/// Defines the myFortDBContext
		/// </summary>
		private readonly MyFortDBContext myFortDBContext;

		/// <summary>
		/// Defines the session
		/// </summary>
		private readonly ISession session;

		/// <summary>
		/// Initializes a new instance of the <see cref="VisitsService"/> class.
		/// </summary>
		/// <param name="session">The session<see cref="ISession"/></param>
		/// <param name="myFortDBContext">The myFortDBContext<see cref="MyFortDBContext"/></param>
		/// <param name="mapper">The mapper<see cref="IMapper"/></param>
		public VisitsService(
			ISession session,
			MyFortDBContext myFortDBContext,
			IMapper mapper)
		{
			this.session = session;
			this.myFortDBContext = myFortDBContext;
			this.mapper = mapper;
		}

		/// <summary>
		/// The AddVisit
		/// </summary>
		/// <param name="visit">The visit<see cref="Visit"/></param>
		/// <returns>The <see cref="Task"/></returns>
		public async Task AddVisit(Visit visit)
		{
			var input = this.mapper.MapVisit(visit);
			input.UserId = this.session.UserID.Value;
			input.VisitedOn = DateTime.Now;

			this.myFortDBContext.Visits.Add(input);
			await this.myFortDBContext.SaveChangesAsync();
		}

		/// <summary>
		/// The GetAllMyVisits
		/// </summary>
		/// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
		/// <returns>The <see cref="Task{List{Visit}}"/></returns>
		public async Task<List<Visit>> GetAllMyVisits(DateTime dateTime)
		{
			var visits = await this.myFortDBContext.Visits
				.Include(x => x.User)
				.Include(x => x.Outlet)
				.Where(x => x.UserId == this.session.UserID.Value && x.VisitedOn.Date == dateTime.Date)
				.ToListAsync();
			return visits.Select(x => this.mapper.MapVisit(x)).ToList();
		}

		/// <summary>
		/// The GetAllTodaysVisits
		/// </summary>
		/// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
		/// <returns>The <see cref="Task{List{Visit}}"/></returns>
		public async Task<List<Visit>> GetAllTodaysVisits(DateTime dateTime)
		{
			var visits = await this.myFortDBContext.Visits
				.Include(x => x.User)
				.Include(x => x.Outlet)
				.Where(x => x.VisitedOn.Date == dateTime.Date)
				.ToListAsync();
			return visits.Select(x => this.mapper.MapVisit(x)).ToList();
		}
	}
}
