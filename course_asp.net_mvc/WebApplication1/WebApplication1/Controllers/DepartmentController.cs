using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context=new ITIContext();

        public IActionResult Departments()
        {


            List<Department> departments=context.Departments.ToList();

            return View("Index",departments);  
        }


    }
}
