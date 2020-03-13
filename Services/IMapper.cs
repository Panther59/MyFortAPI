// <copyright file="IMapper.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-13</date>

namespace MyFortAPI.Services
{
	using MyFortAPI.Data;
	using MyFortAPI.Models;

	/// <summary>
	/// Defines the <see cref="IMapper" />
	/// </summary>
	public interface IMapper
	{
		/// <summary>
		/// The MapOutlet
		/// </summary>
		/// <param name="input">The input<see cref="Outlet"/></param>
		/// <returns>The <see cref="Outlets"/></returns>
		Outlets MapOutlet(Outlet input);

		/// <summary>
		/// The MapOutlet
		/// </summary>
		/// <param name="input">The input<see cref="Outlets"/></param>
		/// <returns>The <see cref="Outlet"/></returns>
		Outlet MapOutlet(Outlets input);

		/// <summary>
		/// The MapUser
		/// </summary>
		/// <param name="user">The user<see cref="Users"/></param>
		/// <returns>The <see cref="User"/></returns>
		User MapUser(Users user);

		/// <summary>
		/// The MapVisit
		/// </summary>
		/// <param name="input">The input<see cref="Visit"/></param>
		/// <returns>The <see cref="Visits"/></returns>
		Visits MapVisit(Visit input);

		/// <summary>
		/// The MapVisit
		/// </summary>
		/// <param name="input">The input<see cref="Visits"/></param>
		/// <returns>The <see cref="Visit"/></returns>
		Visit MapVisit(Visits input);
	}
}
