using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{

    // this attribute to check if the course is unique but depend on department
    public class UniqueCourseAttribute : ValidationAttribute
    {

        public ITIContext Context=new ITIContext(); 

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var myobject = (Course)validationContext.ObjectInstance;
            int id=myobject.DepartmentId;

            string name = value.ToString()!;// we must convert type of value from object to string
            Course course = Context.Courses.FirstOrDefault(c=> c.Name == name&&c.DepartmentId==id);
            if (course == null) {

                return ValidationResult.Success;

            }






            return new ValidationResult("we found course in the same department with the same name");
        }
    }
}
