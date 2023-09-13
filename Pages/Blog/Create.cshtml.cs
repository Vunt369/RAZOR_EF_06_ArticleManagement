using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RAZOR_EF_06_ArticleManagement.Models;
using RAZOR_EF_06_ArticleManagement.Services;

namespace RAZOR_EF_06_ArticleManagement.Pages_Blog
{
    public class CreateModel : PageModel
    {
        private readonly RAZOR_EF_06_ArticleManagement.Models.MyBlogContext _context;
        private readonly ArticleService articleService;
        public CreateModel(RAZOR_EF_06_ArticleManagement.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.articles.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
