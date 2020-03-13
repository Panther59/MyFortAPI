// <copyright file="IOutletService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-13</date>

namespace MyFortAPI.Services
{
	using MyFortAPI.Models;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="IOutletService" />
	/// </summary>
	public interface IOutletService
	{
		/// <summary>
		/// The AddOutlet
		/// </summary>
		/// <param name="outlet">The outlet<see cref="Outlet"/></param>
		/// <returns>The <see cref="Task"/></returns>
		Task AddOutlet(Outlet outlet);

		/// <summary>
		/// The GetAllOutlets
		/// </summary>
		/// <returns>The <see cref="Task{List{Outlet}}"/></returns>
		Task<List<Outlet>> GetAllOutlets();

		/// <summary>
		/// The UpdateOutlet
		/// </summary>
		/// <param name="outlet">The outlet<see cref="Outlet"/></param>
		/// <returns>The <see cref="Task"/></returns>
		Task UpdateOutlet(Outlet outlet);
	}
}
