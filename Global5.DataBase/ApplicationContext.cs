using Global5.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace Global5.DataBase
{
	public class ApplicationContext : DbContext
	{
		public virtual DbSet<User> Users { get; set; }

		#region Construtores

		public ApplicationContext()
		{

		}

		public ApplicationContext( DbContextOptions<ApplicationContext> options)
			: base( options )
		{
		
		}

		#endregion

		protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder)
		{
			if ( !optionsBuilder.IsConfigured ) optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=db_teste;Username=postgres;Password=admin");
			//if ( !optionsBuilder.IsConfigured ) optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=db_teste;User Id=sa;Password=zlx@5050;");
		}
	}
}