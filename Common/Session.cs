// <copyright file="Session.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-02-28</date>

namespace MyFortAPI.Common
{
	using Microsoft.AspNetCore.Http;
	using System.Linq;
	using System.Security.Claims;

	/// <summary>
	/// Defines the <see cref="Session" />
	/// </summary>
	public class Session : ISession
	{
		/// <summary>
		/// Defines the httpContextAccessor
		/// </summary>
		private readonly IHttpContextAccessor httpContextAccessor;

		/// <summary>
		/// Initializes a new instance of the <see cref="Session"/> class.
		/// </summary>
		/// <param name="httpContextAccessor">The httpContextAccessor<see cref="IHttpContextAccessor"/></param>
		public Session(IHttpContextAccessor httpContextAccessor)
		{
			this.httpContextAccessor = httpContextAccessor;
		}

		/// <inheritdoc />
		public int? UserID
		{
			get
			{
				var idText = this.httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
				if (int.TryParse(idText, out int id))
				{
					return id;
				}
				else
				{
					return null;
				}
			}
		}
	}
}
