using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosModel
{
    public class SuperZapatosContext : DbContext
    {

        public SuperZapatosContext()
            : base("Name=SuperZapatosContext")
        {
        }

        public DbSet<Article> Article { get; set; }
        public DbSet<Store> Store { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<Article>().HasKey(x => x.id);
            modelBuilder.Entity<Article>().Property(x => x.id).HasDatabaseGeneratedOption(null);
            modelBuilder.Entity<Article>().Property(x => x.name).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.name).HasColumnType("varchar");
            modelBuilder.Entity<Article>().Property(x => x.name).HasMaxLength(250);
            modelBuilder.Entity<Article>().Property(x => x.price).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.store_id).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.total_in_shelf).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.total_in_vault).IsRequired();


            modelBuilder.Entity<Store>().HasKey(x => x.id);
            modelBuilder.Entity<Store>().Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Store>().Property(x => x.name).IsRequired();
            modelBuilder.Entity<Store>().Property(x => x.name).HasColumnType("varchar");
            modelBuilder.Entity<Store>().Property(x => x.name).HasMaxLength(250);

            modelBuilder.Entity<Article>().HasRequired(x => x.store).WithMany(x => x.article).HasForeignKey(x => x.store_id).WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
