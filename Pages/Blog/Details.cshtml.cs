using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RAZOR_EF_06_ArticleManagement.Models;

namespace RAZOR_EF_06_ArticleManagement.Pages_Blog
{
    public class DetailsModel : PageModel
    {
        private readonly RAZOR_EF_06_ArticleManagement.Models.MyBlogContext _context;

        public DetailsModel(RAZOR_EF_06_ArticleManagement.Models.MyBlogContext context)
        {
            _context = context;
        }

        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.articles.FirstOrDefaultAsync(m => m.Id == id);

            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
