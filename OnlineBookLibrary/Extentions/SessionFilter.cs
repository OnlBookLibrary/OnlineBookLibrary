using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using OnlineBookLibrary.Models;

namespace OnlineBookLibrary.Extentions
{
	public class SessionFilter : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			var result = context.HttpContext.Session.GetObjectFromJson<UserSession>("UserDetails");

			if (result == null)
			{
				context.Result = new RedirectResult("~/Accounts/Login");
			}
			else if (result != null && result.RoleId == 3)
			{
				context.Result = new RedirectResult("~/");
			}
		}
	}
}
