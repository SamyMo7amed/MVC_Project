using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; }
        public string address { get; set; }



        
        public int CourseId {  get; set; }
        [ForeignKey(nameof(CourseId))]  
        public Course Course { get; set; }  


        public int DepartmentId {  get; set; }  

        [ForeignKey(nameof(DepartmentId))]  
        public Department Department { get; set; }

    }
}
