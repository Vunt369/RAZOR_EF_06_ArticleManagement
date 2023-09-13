using Microsoft.EntityFrameworkCore;

namespace RAZOR_EF_06_ArticleManagement.Models
{
	// - Nạp chồng OnConfiguring
	public class MyBlogContext :DbContext
	{
		// - DbSet<Product> chính là bảng trong CSDL
		public DbSet<Article> articles { get; set; }

		public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options) 
		{
		
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			//optionsBuilder.UseSqlServer(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
