 
namespace HuseManagement
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HousingManagementDB : DbContext
    {
        public HousingManagementDB()
            : base("name=HousingManagementDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Debts> Debts { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<RepairRequests> RepairRequests { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
    }
}
