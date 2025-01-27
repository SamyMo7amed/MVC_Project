using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel;
namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {

        private ITIContext context = new ITIContext();

        public IActionResult Index()
        {

            CourseListAndDeptList CourseLists = new CourseListAndDeptList();

            CourseLists.DepartmentList = context.Departments.ToList();
            CourseLists.CourseList = context.Courses.ToList();

            return View("Index", CourseLists);
        }
        public IActionResult Details(int Id)
        {


            Course course = context.Courses.FirstOrDefault(c => c.Id == Id)!;
            CourseWithDeptList courseWithDeptList = new CourseWithDeptList();
            courseWithDeptList.Course = course;
            courseWithDeptList.Departments = context.Departments.ToList();

            return View("Details", courseWithDeptList);

        }

        [HttpPost]
        public IActionResult SaveData(int id, Course course)
        {

            Course basecourse = new Course();
            bool flag = false;
            if (id != 0)
            {
                Course baseCourse2 = context.Courses.FirstOrDefault(c => c.Id == id)!;

                basecourse = baseCourse2;
            }
            else
            {
                flag = true;
            }


            if (course.Name == null)
            {
                CourseWithDeptList courseWithDeptList = new CourseWithDeptList();
                courseWithDeptList.Course = course;
                courseWithDeptList.Departments = context.Departments.ToList();

                return View("Details", courseWithDeptList);

            }
            else
            {


                basecourse.Name = course.Name;
                basecourse.Degree = course.Degree;
                basecourse.Mindegree = course.Mindegree;
                basecourse.DepartmentId = course.DepartmentId;
                if (flag)
                {

                    context.Courses.Add(basecourse);


                }
                context.SaveChanges();
                return RedirectToAction("Index");

            }



        }


        public IActionResult AddNew()
        {
            CourseWithDeptList courseWithDeptList = new CourseWithDeptList();

            courseWithDeptList.Course = new Course();
            courseWithDeptList.Departments = context.Departments.ToList();


            return View("Details", courseWithDeptList);
        }

        public HttpRequest GetRequest()
        {
            return Request;
        }


    }
}

