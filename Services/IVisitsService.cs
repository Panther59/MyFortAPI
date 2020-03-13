// <copyright file="IVisitsService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-13</date>

namespace MyFortAPI.Services
{
	using MyFortAPI.Models;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="IVisitsService" />
	/// </summary>
	public interface IVisitsService
	{
		/// <summary>
		/// The AddVisit
		/// </summary>
		/// <param name="visit">The visit<see cref="Visit"/></param>
		/// <returns>The <see cref="Task"/></returns>
		Task AddVisit(Visit visit);

		/// <summary>
		/// The GetAllMyVisits
		/// </summary>
		/// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
		/// <returns>The <see cref="Task{List{Visit}}"/></returns>
		Task<List<Visit>> GetAllMyVisits(DateTime dateTime);

		/// <summary>
		/// The GetAllTodaysVisits
		/// </summary>
		/// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
		/// <returns>The <see cref="Task{List{Visit}}"/></returns>
		Task<List<Visit>> GetAllTodaysVisits(DateTime dateTime);
	}
}
