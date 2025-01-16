using WebApplication1.Models;
namespace WebApplication1.ViewModel
{
    public class InstructorAndListDepartment
    {

         public  Instructor instructor=new Instructor();    
        public List<Department> departmentList = new List<Department>();
        public InstructorAndListDepartment(Instructor intstructor,List<Department> departments)
        {
            this.instructor = intstructor;
            this.departmentList = departments;  
        }
    }
}
