using TUSA.Domain;
using Microsoft.EntityFrameworkCore;
using TUSA.Domain.Entities;
using System.Linq;
using System;
using TUSA.Core;
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
        public DbSet<user_master> user_master { get; set; }
        public DbSet<user_group_metrix> user_group_metrix { get; set; }
        public DbSet<role_master> role_master { get; set; }
        public DbSet<user_login_log> user_login_log { get; set; }
        public DbSet<user_login_fail> user_login_fail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<user_group_metrix>().HasNoKey();
            modelBuilder.Entity<form_field_matrix>().HasKey(c => new { c.module_id, c.form_name,c.field_id });
            modelBuilder.Entity<pdc_project_element_data>(builder =>{
                                                        builder.HasNoKey();
                                                        builder.ToTable("pdc_project_element_data");
                                                    });
            modelBuilder.Entity<dynamic_form_data>().HasKey(c => new { c.module_id, c.field_id,c.Record_id });
            modelBuilder.Entity<group_form_access_matrix>().HasKey(c => new { c.group_id, c.form_id});
            modelBuilder.Entity<quick_access_screens>().HasNoKey();
            modelBuilder.Entity<recently_accessed_screens>().HasNoKey();
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<name_value_pair>().HasNoKey(); 

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
