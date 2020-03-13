// <copyright file="Mapper.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-13</date>

namespace MyFortAPI.Services
{
	using MyFortAPI.Data;
	using MyFortAPI.Models;

	/// <summary>
	/// Defines the <see cref="Mapper" />
	/// </summary>
	public class Mapper : IMapper
	{
		/// <summary>
		/// The MapOutlet
		/// </summary>
		/// <param name="input">The input<see cref="Outlet"/></param>
		/// <returns>The <see cref="Outlets"/></returns>
		public Outlets MapOutlet(Outlet input)
		{
			return new Outlets
			{
				ContactName = input.ContactName,
				ContactNumber = input.ContactNumber,
				Description = input.Description,
				Id = input.Id.HasValue ? input.Id.Value : 0,
				Location = input.Location,
				Name = input.Name,
			};
		}

		/// <summary>
		/// The MapOutlet
		/// </summary>
		/// <param name="input">The input<see cref="Outlets"/></param>
		/// <returns>The <see cref="Outlet"/></returns>
		public Outlet MapOutlet(Outlets input)
		{
			return new Outlet
			{
				ContactName = input.ContactName,
				ContactNumber = input.ContactNumber,
				Description = input.Description,
				Id = input.Id,
				Location = input.Location,
				Name = input.Name,
			};
		}

		/// <summary>
		/// The MapUser
		/// </summary>
		/// <param name="user">The user<see cref="Users"/></param>
		/// <returns>The <see cref="User"/></returns>
		public User MapUser(Users user)
		{
			return new User
			{
				ID = user.Id,
				Email = user.Email,
				FirstName = user.FirstName,
				LastName = user.LastName,
				IsActive = user.IsActive,
				Type = (Models.TypeOfUser)user.Type,
			};
		}

		/// <summary>
		/// The MapVisit
		/// </summary>
		/// <param name="input">The input<see cref="Visit"/></param>
		/// <returns>The <see cref="Visits"/></returns>
		public Visits MapVisit(Visit input)
		{
			return new Visits
			{
				Id = input.Id.HasValue ? input.Id.Value : 0,
				MeetingWith = input.MeetingWith,
				Notes = input.Notes,
				VisitedOn = input.VisitedOn,
				OutletId = input.Outlet.Id.Value,
				UserId = input.User?.ID != null ? input.User.ID.Value : 0,
			};
		}

		/// <summary>
		/// The MapVisit
		/// </summary>
		/// <param name="input">The input<see cref="Visits"/></param>
		/// <returns>The <see cref="Visit"/></returns>
		public Visit MapVisit(Visits input)
		{
			return new Visit
			{
				Id = input.Id,
				MeetingWith = input.MeetingWith,
				Notes = input.Notes,
				VisitedOn = input.VisitedOn,
				Outlet = this.MapOutlet(input.Outlet),
				User = this.MapUser(input.User),
			};
		}
	}
}
