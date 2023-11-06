using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMSApi.Models;

namespace EMSApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        IDepartment repo;
        public DepartmentController(IDepartment _repo)
        {
            this.repo=_repo;
        }  

        [HttpGet]
        [Route("ListDept")]
        public IActionResult GetDept()
        {
            var data=repo.GetDepartments();
            return Ok(data);
        } 
        [HttpPost]
        [Route("Create")]
        public IActionResult PostDept(Department d)
        {
            if(ModelState.IsValid)
            {
                repo.AddDept(d);
                return Created("Added Successfully",d);
            }
            return BadRequest("Unable to add");

        }
        [HttpPost]
        [Route("ListDept/{id}")]
        public IActionResult GetDeptById(int id)
        {
            var data=repo.FindDept(id);
            return Ok(data);
        }

        [HttpPut]
        [Route("EditDept/{id}")]
        public IActionResult PutDept(int id,Department department)
        {
            repo.EditDept(department);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteDept/{id}")]
        public IActionResult Delete(int id)
        {
            repo.DeleteDept(id);
            return Ok("Deleted");
        }
    }
}