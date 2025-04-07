
using Microsoft.AspNetCore.Mvc;
using Cumulative01.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Cumulative01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeacherAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Retrieves a list of all teachers in the system
        /// </summary>
        /// <example>
        /// GET api/TeacherAPI/Teacher
        /// </example>
        /// <returns>A list of Teacher objects containing all teacher details</returns>
        [HttpGet(template: "Teacher")]
        public List<Teacher> ListTeacherNames()
        {
            List<Teacher> teachers = new List<Teacher>();

            MySqlConnection Connection = _context.GetConnection();

            Connection.Open();


            string SQLQuery = "SELECT * FROM teachers";

            MySqlCommand Command = Connection.CreateCommand();

            Command.CommandText = SQLQuery;

            MySqlDataReader DataReader = Command.ExecuteReader();



            while (DataReader.Read())
            {

                int TeacherId = Convert.ToInt32(DataReader["teacherid"]);
                string TeacherFname = DataReader["teacherfname"].ToString();
                string TeacherLname = DataReader["teacherlname"].ToString();
                string EmployeeID = DataReader["employeenumber"].ToString();
                DateTime HireDate = Convert.ToDateTime(DataReader["hiredate"]);
                double Salary = Convert.ToDouble(DataReader["salary"]);

                Teacher newTeacher = new Teacher();
                newTeacher.TeacherId = TeacherId;
                newTeacher.TeacherFname = TeacherFname;
                newTeacher.TeacherLname = TeacherLname;
                newTeacher.EmployeeID = EmployeeID;
                newTeacher.HireDate = HireDate;
                newTeacher.Salary = Salary;

                teachers.Add(newTeacher);


            }

            Connection.Close();



            return teachers;
        }
        [HttpGet]
        [Route(template: "FindTeacher/{id}")]
        /// <summary>
        /// Retrieves a specific teacher by their ID
        /// </summary>
        /// <example>
        /// GET api/TeacherAPI/FindTeacher/5
        /// </example>
        /// <param name="id">The ID of the teacher to retrieve</param>
        /// <returns>A Teacher object containing the teacher's details</returns>
        public Teacher FindTeacher(int id)
        {
            Teacher teacher = new Teacher();

            MySqlConnection Connection = _context.GetConnection();
            Connection.Open();

            string SQL = "Select * FROM teachers Where teacherid = " + id.ToString();

            MySqlCommand Command = Connection.CreateCommand();

            Command.CommandText = SQL;

            MySqlDataReader DataReader = Command.ExecuteReader();


            while (DataReader.Read())
            {
                int TeacherId = Convert.ToInt32(DataReader["teacherid"]);
                string TeacherFname = DataReader["teacherfname"].ToString();
                string TeacherLname = DataReader["teacherlname"].ToString();
                string EmployeeID = DataReader["employeenumber"].ToString();
                DateTime HireDate = Convert.ToDateTime(DataReader["hiredate"]);
                double Salary = Convert.ToDouble(DataReader["salary"]);

                teacher.TeacherId = TeacherId;
                teacher.TeacherFname = TeacherFname;
                teacher.TeacherLname = TeacherLname;
                teacher.EmployeeID = EmployeeID;
                teacher.HireDate = HireDate;
                teacher.Salary = Salary;
            }

            Connection.Close();


            return teacher;
        }







    }
}
