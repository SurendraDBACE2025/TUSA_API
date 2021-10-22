using TUSA.Domain;
using Microsoft.EntityFrameworkCore;
using TUSA.Domain.Entities;
using System.Linq;
using System;
using TUSA.Domain.Entities.Settings;
using TUSA.Core;
using TUSA.Domain.Entities.UserMaster;
using TUSA.Domain.Entities.Privileges;

namespace TUSA.Data
{
    public partial class TUSAContext : DbContext
    {
        IApplicationUser _applicationUser;
        public TUSAContext(DbContextOptions<TUSAContext> options, IApplicationUser applicationUser) : base(options)
        {
            _applicationUser = applicationUser;
        }

       // public DbSet<SequenceNo> SequenceNo { get; set; }
       // public DbSet<LookUpMaster> LookUpMaster { get; set; }
       // public DbSet<LookUpValues> LookUpValues { get; set; }
     //   public DbSet<ValueText> ValueText { get; set; }
        public DbSet<user_master> user_master { get; set; }
      //  public DbSet<Group> Groups { get; set; }
        public DbSet<role_master> role_master { get; set; }
        public DbSet<user_login_log> user_login_log { get; set; }
        public DbSet<user_login_fail> user_login_fail { get; set; }

        public DbSet<pdc_gm_elements_master> pdc_gm_elements_master { get; set; }
        public DbSet<pdc_gm_header> pdc_gm_header { get; set; }
        public DbSet<pdc_gm_project_data> pdc_gm_project_data { get; set; }
        public DbSet<pdc_gm_scopecategry> pdc_gm_scopecategry { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //modelBuilder.Entity<user_master>().HasIndex(u => u.Name).IsUnique();

            //modelBuilder.Entity<Domain.Entities.Billing.PharmacyLine>()
            //    .HasOne(s => s.Invoice).WithMany(g => g.Lines).HasForeignKey(s => s.InvoiceId); 

        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            //https://www.koskila.net/how-to-add-creator-modified-info-to-all-of-your-ef-models-at-once-in-net-core/
            var entities = ChangeTracker.Entries().Where(x => x.Entity is AuditEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((AuditEntity)entity.Entity).created_date = DateTime.Now;
                    ((AuditEntity)entity.Entity).created_by = (_applicationUser.UserId == 0 ? 0 : _applicationUser.UserId);
                }
                else if (entity.State == EntityState.Modified)
                {
                    Entry((AuditEntity)entity.Entity).Property(p => p.created_date).IsModified = false;
                    Entry((AuditEntity)entity.Entity).Property(p => p.created_by).IsModified = false;
                    ((AuditEntity)entity.Entity).modified_date = DateTime.Now;
                    ((AuditEntity)entity.Entity).modified_by = _applicationUser.UserId == 0 ?0 : _applicationUser.UserId ;
                    //if(entity.Entity.GetType().GetProperty("ModifiedDate") != null)
                    //{
                    //    ((BaseEntity)entity.Entity).ModifiedDate = DateTime.Now;
                    //}
                }
            }
        }
    }
}
