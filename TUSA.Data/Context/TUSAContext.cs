using TUSA.Domain;
using Microsoft.EntityFrameworkCore;
using TUSA.Domain.Entities;
using System.Linq;
using System;
using TUSA.Domain.Entities.Settings;
using TUSA.Core;
using TUSA.Domain.Entities;
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

        public DbSet<pdc_element_master> pdc_element_master { get; set; }
        public DbSet<pdc_header_data> pdc_header_data { get; set; }
        public DbSet<pdc_project_element_data> pdc_project_element_data { get; set; }
        public DbSet<pdc_category_master> pdc_category_master { get; set; }
        public DbSet<pdc_platform_master> pdc_platform_master { get; set; }
        public DbSet<pdc_platform_category_matrix> pdc_platform_category_matrix { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<pdc_element_master>().HasKey(c => new { c.element_id, c.category_id });
            modelBuilder.Entity<pdc_header_data>().HasKey(c => new { c.header_Id, c.platform_id });
            modelBuilder.Entity<pdc_platform_category_matrix>().HasKey(c => new { c.matrix_id, c.platform_id });
            modelBuilder.Entity<pdc_project_element_data>(builder =>{
                                                        builder.HasNoKey();
                                                        builder.ToTable("pdc_project_element_data");
                                                    });
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
                    ((AuditEntity)entity.Entity).created_by = (_applicationUser.UserId == "" ? "" : _applicationUser.UserId);
                }
                else if (entity.State == EntityState.Modified)
                {
                    Entry((AuditEntity)entity.Entity).Property(p => p.created_date).IsModified = false;
                    Entry((AuditEntity)entity.Entity).Property(p => p.created_by).IsModified = false;
                    ((AuditEntity)entity.Entity).modified_date = DateTime.Now;
                    ((AuditEntity)entity.Entity).modified_by = _applicationUser.UserId == "" ?"" : _applicationUser.UserId ;
                    //if(entity.Entity.GetType().GetProperty("ModifiedDate") != null)
                    //{
                    //    ((BaseEntity)entity.Entity).ModifiedDate = DateTime.Now;
                    //}
                }
            }
        }
    }
}
