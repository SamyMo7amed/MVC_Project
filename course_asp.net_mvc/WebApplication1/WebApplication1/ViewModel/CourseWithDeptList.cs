using WebApplication1.Models;

namespace WebApplication1.ViewModel
{
    public class CourseWithDeptList
    {
        public Course? Course { get; set; }
        public List<Department> Departments { get; set; }

    }
}
