using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidationProject.Helpers;
using FluentValidationProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationProject.Controllers
{
    public class StudentController : ControllerBase
    {

        [HttpPost]
        [Route("Student/CreateAsync")]
        [NormalizeInputs]
        public async Task<IActionResult> createAsync([FromBody] CreateStudentViewModel model, string value, int code)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }



        [HttpPost]
        [Route("Student/create")]
        [NormalizeInputs]
        public async Task<IActionResult> create(StudentType studentType , [FromBody] CreateStudentViewModel model,string nationalCode, string firstName, int age)
        {
            var result = new CreatedResult()
            {
                NationalCode = nationalCode,
                FirstName = firstName,
                Age = age,
                Model = model,
                StudentType = studentType,
            };
            return Ok(result);
        }
    }





    public class CreatedResult
    {
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public StudentType StudentType { get; set; }
        public CreateStudentViewModel Model { get; set; }
    }
}
