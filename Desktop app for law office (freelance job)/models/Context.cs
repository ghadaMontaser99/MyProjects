using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace project.models
{
   public class Context: DbContext
	{
        public DbSet<Users> Users { get; set; }
        public DbSet<Case> Case { get; set; }
        public DbSet<CourtDates> CourtDates { get; set; }
        public DbSet<Case_CourtDates> Case_Court_dates { get; set; }
        public DbSet<Case_User> CaseUser { get; set; }
        public DbSet<ImagesCases> ImagesCases { get; set; }
        public Context()
		{

		}
		//public DbSet<Branches> Branch { get; set; }
		

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseSqlServer("Data source=.\\SQL19; initial catalog = CaseDB; Integrated Security=True;Encrypt=False");

        }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(r => r.GetForeignKeys()))
			{
				relation.DeleteBehavior = DeleteBehavior.NoAction;
			}
		}
	}
}
