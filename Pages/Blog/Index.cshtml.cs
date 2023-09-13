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
    public class IndexModel : PageModel
    {
        private readonly RAZOR_EF_06_ArticleManagement.Models.MyBlogContext _context;

        public IndexModel(RAZOR_EF_06_ArticleManagement.Models.MyBlogContext context)
        {
            _context = context;
        }
        private const int ITEMS_PER_PAGE = 10;

        [BindProperty(SupportsGet =true, Name ="p")]
        public int currenPage {  get; set; }
        public int countPage { get; set; }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync(string SearchValue)
        {
            int totalArticle =await _context.articles.CountAsync();
            countPage =(int) Math.Ceiling((double)totalArticle/ ITEMS_PER_PAGE);
            if (currenPage < 1) currenPage = 1;
            if (currenPage > countPage) currenPage = countPage;


            var qr = (from article in _context.articles
                      orderby article.Created descending
                      select article).
                      Skip((currenPage-1)* ITEMS_PER_PAGE).
                      Take(ITEMS_PER_PAGE);


            if (!string.IsNullOrEmpty(SearchValue))
            {
                Article = qr.Where(a => a.Title.Contains(SearchValue.Trim())).ToList();
            }
            else
            {
                Article = await qr.ToListAsync();
            }
               
        }
      
    }
}
