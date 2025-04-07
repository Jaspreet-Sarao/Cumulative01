using Cumulative01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative01.Controllers
{
    public class TeacherPageController : Controller
    {


        private readonly TeacherAPIController _api;

        /// <summary>
        /// Initializes a new instance of the TeacherPageController
        /// </summary>
        /// <param name="api">The TeacherAPIController instance for data access</param>
        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }
        /// <summary>
        /// Displays a list of all teachers
        /// </summary>
        /// <returns>A view containing the list of teachers</returns>
        public IActionResult List()
        {
            List<Teacher> Teach = _api.ListTeacherNames();
            return View(Teach);
        }
        /// <summary>
        /// Displays details for a specific teacher
        /// </summary>
        /// <param name="Id">The ID of the teacher to display</param>
        /// <returns>A view containing the teacher's details</returns>
        /// <example>
        /// GET /TeacherPage/Show/5
        /// </example>
        public IActionResult Show(int Id)
        {

            Teacher teach1 = _api.FindTeacher(Id);
            return View(teach1);
        }
    }
}
