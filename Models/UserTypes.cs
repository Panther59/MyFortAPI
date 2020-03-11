// <copyright file="UserTypes.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-02-29</date>

namespace MyFortAPI.Models
{
	/// <summary>
	/// Defines the TypeOfUser
	/// </summary>
	public enum TypeOfUser
	{
		/// <summary>
		/// Defines the RegularUser
		/// </summary>
		RegularUser = 1,

		/// <summary>
		/// Defines the Supervisor
		/// </summary>
		Supervisor = 2,

		/// <summary>
		/// Defines the Admin
		/// </summary>
		Admin = 4,

		/// <summary>
		/// Defines the ITAdmin
		/// </summary>
		ITAdmin = 8,
	}
}
