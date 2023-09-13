using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RAZOR_EF_06_ArticleManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAZOR_EF_06_ArticleManagement.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public readonly MyBlogContext myBlogContext;
		public IndexModel(ILogger<IndexModel> logger, MyBlogContext context)
		{
			_logger = logger;
			myBlogContext = context;
		}

		public void OnGet()
		{
			var post = (from p in myBlogContext.articles
                        orderby p.Created descending
                        select p).ToList();
			ViewData["posts"] = post;
		}
	}
}
