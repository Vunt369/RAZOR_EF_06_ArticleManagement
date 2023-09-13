using RAZOR_EF_06_ArticleManagement.Models;
using System.Linq;
namespace RAZOR_EF_06_ArticleManagement.Services
{
    public class ArticleService
    {
        private MyBlogContext blogContext;
        public ArticleService(MyBlogContext context) 
        {
        blogContext = context;
        }

        public bool CheckIsPostExists(string title)
        {
            var post = (from a in blogContext.articles
                        select a).ToList();

            foreach (var item in post)
            {
                if (item.Title.Trim() == title.Trim())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
