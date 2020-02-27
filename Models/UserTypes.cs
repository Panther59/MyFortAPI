using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFortAPI.Models
{
	public enum UserTypes
	{
		RegularUser = 1,
		Supervisor = 2,
		OpertionHead = 4,
		Admin = 8,
		ITAdmin = 16,
	}
}
