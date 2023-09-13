using System;

namespace RAZOR_EF_06_ArticleManagement.Helpers
{
    public class PagingModel
    {
        public int currentPage { get; set; }
        public int countPage { get; set; }
        public Func<int?, string> generateUrl { get; set; }


    }
}
