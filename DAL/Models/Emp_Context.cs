using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DAL.Models
{
    public class Emp_Context : DbContext
    {
        public Emp_Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Emp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(x =>
            {
                //x.HasKey("Emp_Id");
                //x.ToTable("Employee");
                //x.Property<int>("Emp_Id");
                //x.Property<string>("Emp_Name");
                //x.Property<string>("Emp_Password");
                //x.Property<float>("Emp_Sal");
                //x.Property<string>("Emp_Gnder");
                //x.Property<string>("Emp_Email");
                //x.Property<DateTime>("Emp_Dob");

            });
            // OnModelCreatingPartial(modelBuilder);
        }
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
