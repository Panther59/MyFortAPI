// <copyright file="OutletService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-13</date>

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
	/// Defines the <see cref="OutletService" />
	/// </summary>
	public class OutletService : IOutletService
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
		/// Initializes a new instance of the <see cref="OutletService"/> class.
		/// </summary>
		/// <param name="session">The session<see cref="ISession"/></param>
		/// <param name="myFortDBContext">The myFortDBContext<see cref="MyFortDBContext"/></param>
		/// <param name="mapper">The mapper<see cref="IMapper"/></param>
		public OutletService(
			ISession session,
			MyFortDBContext myFortDBContext,
			IMapper mapper)
		{
			this.session = session;
			this.myFortDBContext = myFortDBContext;
			this.mapper = mapper;
		}

		/// <summary>
		/// The AddOutlet
		/// </summary>
		/// <param name="outlet">The outlet<see cref="Outlet"/></param>
		/// <returns>The <see cref="Task"/></returns>
		public async Task AddOutlet(Outlet outlet)
		{
			var input = this.mapper.MapOutlet(outlet);
			input.LastModifiedOn = DateTime.Now;
			input.LastModifiedBy = this.session.UserID.Value;

			await myFortDBContext.AddAsync(input);
			await myFortDBContext.SaveChangesAsync();
		}

		/// <summary>
		/// The GetAllOutlets
		/// </summary>
		/// <returns>The <see cref="Task{List{Outlet}}"/></returns>
		public async Task<List<Outlet>> GetAllOutlets()
		{
			var outlets = await this.myFortDBContext.Outlets.ToListAsync();
			return outlets.Select(x => this.mapper.MapOutlet(x)).ToList();
		}

		/// <summary>
		/// The UpdateOutlet
		/// </summary>
		/// <param name="outlet">The outlet<see cref="Outlet"/></param>
		/// <returns>The <see cref="Task"/></returns>
		public async Task UpdateOutlet(Outlet outlet)
		{
			var existingOutlet = await this.myFortDBContext.Outlets.FirstOrDefaultAsync<MyFortAPI.Data.Outlets>(x => x.Id == outlet.Id);
			if (existingOutlet != null)
			{
				existingOutlet.ContactName = outlet.ContactName ?? existingOutlet.ContactName;
				existingOutlet.ContactNumber = outlet.ContactNumber ?? existingOutlet.ContactNumber;
				existingOutlet.Description = outlet.Description ?? existingOutlet.Description;
				existingOutlet.Location = outlet.Location ?? existingOutlet.Location;
				existingOutlet.Name = outlet.Name ?? existingOutlet.Name;
				existingOutlet.LastModifiedOn = DateTime.Now;
				existingOutlet.LastModifiedBy = this.session.UserID.Value;

				this.myFortDBContext.Update(existingOutlet);
				await this.myFortDBContext.SaveChangesAsync();
			}
			else
			{
				throw new Exception("No such outlet found to update");
			}
		}
	}
}
