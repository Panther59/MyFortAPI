using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyFortAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyFortAPI.Filters
{
	public class UserRoleFilter : IAuthorizationFilter
	{
		readonly string _claim;
		readonly UserTypes _value;

		public UserRoleFilter(string claim, UserTypes value)
		{
			_claim = claim;
			_value = value;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var inputValue = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == _claim);
			if (inputValue == null || !_value.HasFlag((UserTypes)Enum.Parse(typeof(UserTypes), inputValue.Value)))
			{
				context.Result = new ForbidResult();
			}
		}
	}
}
