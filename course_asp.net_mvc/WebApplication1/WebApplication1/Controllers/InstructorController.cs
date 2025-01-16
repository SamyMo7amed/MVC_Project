using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using WebApplication1.Models;
using WebApplication1.ViewModel;


namespace WebApplication1.Controllers
{
    public class InstructorController : Controller
    {

        private  ITIContext _context=new ITIContext();

        public IActionResult Index()
        {
            List<Instructor> instructors = _context.Instructors.ToList();


            return View("Index",instructors);
        }
        
        public IActionResult Details(int id)
        {
            Instructor inst=_context.Instructors.FirstOrDefault(x => x.Id == id)!;  
            List<Department> depts=_context.Departments.ToList();   
            // create object form view model to send to view d details as complex data i  aggregate them in one class
            InstructorAndListDepartment data=new InstructorAndListDepartment(inst,depts);
            


            return View("Details",data);
        }
        [HttpPost]
        public IActionResult SaveData(int id,Instructor instructor)
        {
            Instructor baseInstruct=_context.Instructors.FirstOrDefault(x=>x.Id == id);
            if (instructor.Name != null) { //name is required
                baseInstruct.Name=instructor.Name;
                baseInstruct.address=instructor.address;
                baseInstruct.Salary=instructor.Salary;  
                baseInstruct.DepartmentId=instructor.DepartmentId;
                _context.SaveChanges();
               return RedirectToAction("Index");
               

            } 
            InstructorAndListDepartment ins=new InstructorAndListDepartment(instructor,
                _context.Departments.ToList());
            return View("Details",ins);
            
        }

    }
}
