using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
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
         */
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }


        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

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