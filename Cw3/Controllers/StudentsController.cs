
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;



namespace cw3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        

       

        [HttpGet]
        public IActionResult GetStudent()
        {
            var list = new List<Student>();
            
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19391;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText ="select * from Student " + "inner join Enrollment on Student.IdEnrollment = Enrollment.IdEnrollment " + "inner join Studies on Studies.IdStudy = Enrollment.IdStudy";

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    st.NameOfStudies = dr["Name"].ToString();
                    list.Add(st);
                }

            }

            return Ok(list);
        }

        [HttpGet("{IndexNumber}")]
        public IActionResult GetStEnroll(string IndexNumber)
        {
            
            var list2 = new List<Enrollment>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s19391;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Enrollment inner join Student on Enrollment.IdEnrollment = Student.IdEnrollment where Student.IndexNumber = @id";
                com.Parameters.AddWithValue("id", IndexNumber);

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var en = new Enrollment();
                    en.IdEnrollment = dr["IdEnrollment"].ToString();
                    en.Semester = dr["Semester"].ToString();
                    en.IdStudy = dr["IdStudy"].ToString();
                    en.StartDate = dr["StartDate"].ToString();
                    list2.Add(en);
                }

                return Ok(list2);
            }

        }

        [HttpDelete]
            public IActionResult DeleteStudent(string id)
            {
            //delete 
            return Ok($"Usuwanie dokończone {id}");
            }


        [HttpPut]
            public IActionResult PutStudent(string id)
            {
            //change
            return Ok($"Aktualizacja dokończona {id}");
            }


        [HttpPost]

            public IActionResult CreateStudent(Student student)
            {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
            }






    }
}





// private static List<Student> students = new List<Student>();

/*

        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            var list = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Student";

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    list.Add(st);
                }
            }
        
            return Ok(list);
            
            
        }

        /*
                [HttpGet]
                public IActionResult GetStudent(string orderBy)
                {
                   
                    return Ok(_dbService.GetStudents());


                }

        */

/*
[HttpGet("{id}")]

public IActionResult GetStudent(int id)
{
    if (id == 1)
    {
        return Ok("Kowalski");
    }else if (id == 2)
    {
        return Ok("Malewski");
    }
    return NotFound("Nie znaleziono studenta");
}




}
*/
/*
    [HttpGet]
    public string GetStudent()
    {
        return "Kowalski, Malewski, Andrzejewski";
    }

    [HttpGet("{id}")]
    */
/*
 [HttpGet]
public string GetStudent(string orderBy)
{
    return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
}





}
*/
