using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAZOR_EF_06_ArticleManagement.Models
{
	public class Article
	{
		[Key]
		public int Id { get; set; }

		[StringLength(255, MinimumLength =5, ErrorMessage ="{0} phải dài từ {2} đến {1} ký tự")]
		[Required(ErrorMessage ="{0} không được bỏ trống")]
		[Column(TypeName = "nvarchar")]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

		[DataType(DataType.DateTime)]
		[Required(ErrorMessage = "{0} không được bỏ trống")]
        [Display(Name = "Ngày đăng")]
        public DateTime Created {  get; set; }

		[Column(TypeName ="ntext")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

	}
}
