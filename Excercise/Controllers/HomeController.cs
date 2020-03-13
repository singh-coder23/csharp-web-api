using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Excercise.Models;
using Excercise.Repository;
using Excercise.DTO;
using System.Security.Claims;

namespace Excercise.Controllers
{
    [Produces("application/json")]
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        quipserveContext dbcontext = new quipserveContext();
        HomeRepository objHomeRepository = new HomeRepository();

        [HttpGet]
        [Route("getAllEmployeeDetails")]
        public IActionResult getAllEmployeeDetails()
        {
            try
            {
                var x = Request.Headers.Values.FirstOrDefault();
                Response objResponse = objHomeRepository.getAllEmployess();
                return Ok(objResponse);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("insertData")]
        public IActionResult insertData([FromBody]HomeDTO objHomeDTO)
        {
            try
            {
                Response objResponse = objHomeRepository.insertEmployeeData(objHomeDTO);
                return Ok(objResponse);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("updateData")]
        public IActionResult updateData([FromBody]HomeDTO objHomeDTO)
        {
            try
            {
                Response objResponse = objHomeRepository.updateEmployeeData(objHomeDTO);
                return Ok(objResponse);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("deleteData")]
        public IActionResult Delete([FromBody]HomeDTO objHomeDTO)
        {
            try
            {
                Response objResponse = objHomeRepository.deleteEmployeeData(objHomeDTO);
                return Ok(objResponse);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}