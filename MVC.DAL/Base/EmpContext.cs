using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
 
namespace MVC.DAL
{
     [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))] 
    public partial class EmpContext : DbContext
    {
        private string _userName;

        public EmpContext()
            : base("name=HgmasDBEntities")
        {
        }

        public EmpContext(string userName)
            : this()
        {
            this._userName = userName;
        }

        public virtual DbSet<T_User> T_Users { get; set; }
        public virtual DbSet<T_Tree> T_Trees { get; set; }
        public virtual DbSet<T_Company> T_Companys { get; set; }
        public virtual DbSet<T_Sys> T_Syss { get; set; }
        public virtual DbSet<T_SysList> T_SysLists { get; set; }
        public virtual DbSet<T_Role> T_Roles { get; set; }
        public virtual DbSet<T_Log> T_Logs { get; set; }
        public virtual DbSet<T_Supplier> T_Suppliers { get; set; }
        public virtual DbSet<T_Client> T_Clients { get; set; }
        public virtual DbSet<T_Project> T_Projects { get; set; }
        public virtual DbSet<T_Department> T_Departments { get; set; }
        public virtual DbSet<T_ProjectUser> T_ProjectUsers { get; set; }
        public virtual DbSet<T_Agree> T_Agrees { get; set; }
        public virtual DbSet<T_AgreeList> T_AgreeLists { get; set; }
        public virtual DbSet<T_LeaveSetting> T_LeaveSettings { get; set; }
        public virtual DbSet<T_LeaveApply> T_LeaveApplys { get; set; }
        public virtual DbSet<T_LeaveCarryOver> T_LeaveCarryOvers { get; set; }
        public virtual DbSet<T_FixedAssets> T_FixedAssetss { get; set; }
        public virtual DbSet<T_FixedAssetsUse> T_FixedAssetsUses { get; set; } 
          
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_SysList>()
               .HasMany(e => e.ChildSysList)
               .WithOptional(e => e.ParSysList)
               .HasForeignKey(e => e.ParentId);

            //用户与公司的外键 这种是必须存在的主外键关系
            modelBuilder.Entity<T_Company>()
             .HasMany(e => e.Users)
             .WithRequired(e => e.Company); 

            //modelBuilder.Entity<T_SysList>()
            //   .HasMany(e => e.Group)
            //   .WithOptional(e => e.Group)
            //   .HasForeignKey(e => e.GroupId)
            //    .WillCascadeOnDelete();
 
 
        }

    }
}
