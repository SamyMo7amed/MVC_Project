using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Course
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="required")]
        [MinLength(3,ErrorMessage = "less than 3 chars")]
        [MaxLength(15)]
        [UniqueCourse]
        public string Name { get; set; }

        [Range(50, 100)]
        public  int Degree { get; set; }


       
        public int Mindegree { get; set; }

        
   
        public List<Instructor> instructors { get; set; } 

        public List<CourseResult> coursesRSLT { get; set; }


        public int DepartmentId {  get; set; }

        [ForeignKey(nameof(DepartmentId))]  
        public Department Department { get; set; }  

    }
}
