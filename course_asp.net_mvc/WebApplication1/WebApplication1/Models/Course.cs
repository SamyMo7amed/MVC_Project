using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Course
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        
        public  int Degree {  get; set; }   
        public int Mindegree { get; set; }

   
        public List<Instructor> instructors { get; set; } 

        public List<CourseResult> coursesRSLT { get; set; }


        public int DepartmentId {  get; set; }

        [ForeignKey(nameof(DepartmentId))]  
        public Department Department { get; set; }  

    }
}
