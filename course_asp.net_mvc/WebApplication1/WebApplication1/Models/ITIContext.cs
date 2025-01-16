using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Models
{
    public class ITIContext :DbContext
    {
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; } 
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> courseResults { get; set; }
        public DbSet<Trainee> Trainees { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-N5JLDA3\\SQLEXPRESS;Initial Catalog=MVC ;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");


            base.OnConfiguring(optionsBuilder);

            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasMany(x => x.instructors).WithOne(x => x.Course).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Course>().HasOne(x => x.Department).WithMany(x => x.Courses).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Course>().HasMany(X=>X.coursesRSLT).WithOne().HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CourseResult>().HasOne(x => x.Trainee).WithMany(x => x.CoursesRSLT).HasForeignKey(x=>x.TraineeId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Trainee>().HasOne<Department>().WithMany(x=>x.Trainees).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Department>().HasMany(x => x.Instructors).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Restrict); 


        }






    }
}
