using System.Data.Entity;
using CallTime.Data.Models;

namespace CallTime.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection") { }
        
        //public DbSet<Banner> Banners { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Visit> Visits { get; set; }
        //public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            #region [ User ]

            mb.Entity<User>().Property(_ => _.Login).HasMaxLength(128);
            mb.Entity<User>().Property(_ => _.Email).HasMaxLength(128);
            mb.Entity<User>().Property(_ => _.PasswordHash).HasMaxLength(128);
            mb.Entity<User>().Property(_ => _.Email).IsRequired();
            mb.Entity<User>().Property(_ => _.PasswordHash).IsRequired();

            #endregion

            #region [ Role ]

            mb.Entity<Role>().Property(_ => _.Name).HasMaxLength(128);
            mb.Entity<Role>().Property(_ => _.Name).IsRequired();

            #endregion

            #region [ Setting ]

            //mb.Entity<Setting>().Property(x => x.Value).HasMaxLength(256);

            #endregion
        }
    }
}
