using Microsoft.AspNetCore.Mvc;
using MyFortAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFortAPI.Filters
{
	public class UserTypeFilterAttribute : TypeFilterAttribute
	{
		public UserTypeFilterAttribute(string claim, UserTypes value) : base(typeof(UserRoleFilter))
		{
			Arguments = new object[] { claim, value };
		}
	}
}
