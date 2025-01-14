using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Trainee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
         public double Grade {  get; set; } 

        public List<CourseResult> CoursesRSLT { get; set; }

              [ForeignKey(nameof(Department1))]
        public int DepartmentId {  get; set; }
        public Department Department1 { get; set; }


    }
}
