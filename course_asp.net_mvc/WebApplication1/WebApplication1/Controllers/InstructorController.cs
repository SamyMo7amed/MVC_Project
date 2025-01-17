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
            
            
            Instructor baseInstruct=new Instructor();
            bool Flag = false;//this flag to avoid wirte some code  when i add the new instructor in database
            if (id != 0)
            {
                Instructor baseInstruct2=_context.Instructors.FirstOrDefault(x=>x.Id == id)!;
                baseInstruct = baseInstruct2;
            }
            else {
                Instructor newInstructor=new Instructor();
                baseInstruct=new Instructor();  
                Flag = true;
                
                
            }
           
            if (instructor.Name != null) { //name is required
                baseInstruct.Name=instructor.Name;
                baseInstruct.address=instructor.address;
                baseInstruct.Salary=instructor.Salary;  
                baseInstruct.DepartmentId=instructor.DepartmentId;
                if (Flag == true) {
                    baseInstruct.Image = instructor.Image;
                    // this line of code to git the courseId not the best because  their is another courses linked with the same department but in temprary
                   int  courseId=(_context.Courses.FirstOrDefault(x=>x.DepartmentId==instructor.DepartmentId).Id)!;
                    baseInstruct.CourseId=courseId; 
                    _context.Instructors.Add(baseInstruct); 
                }
                _context.SaveChanges();
               return RedirectToAction("Index");
               

            } 
            // if the name is null 
            InstructorAndListDepartment ins=new InstructorAndListDepartment(instructor,
                _context.Departments.ToList());
            return View("Details",ins);
            
        }


        //Action Return view that add new instructor 
        public IActionResult AddInstructor()
        {

            InstructorAndListDepartment ins = new InstructorAndListDepartment(new Instructor(),
                _context.Departments.ToList());
            return View("Details",ins);
        }
    }
}
