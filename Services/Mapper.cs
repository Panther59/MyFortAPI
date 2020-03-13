using MyFortAPI.Data;
using MyFortAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFortAPI.Services
{
	public class Mapper : IMapper
	{
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
	}
}
