using Excercise.DTO;
using Excercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercise.Repository
{
    public class HomeRepository
    {
        quipserveContext dbcontext = new quipserveContext();
        public Response getAllEmployess()
        {
            var xdata = dbcontext.Employee.ToList();
            var xtoken = Utilities.JWTHandler.GenerateToken(xdata.FirstOrDefault().FirstName);
            Response response = new Response()
            {
                Message = "Employee data retrieved successfully",
                Status = true,
                Data = new { xdata, xtoken }
            };
            return response;
        }

        public Response insertEmployeeData(HomeDTO objHomeDTO)
        {
            Employee objEmployee = new Employee()
            {
                FirstName = objHomeDTO.FirstName,
                LastName = objHomeDTO.LastName,
                Address = objHomeDTO.Address,
                IsStudent = objHomeDTO.IsStudent,
                CreatedAt = System.DateTime.Now,
                UpdatedAt = System.DateTime.Now
            };

            dbcontext.Employee.Add(objEmployee);
            dbcontext.SaveChanges();
            Response response = new Response()
            {
                Message = "Data is inserted successfully..",
                Status = true,
                Data = new Array[0]
            };

            return response;
        }

        public Response updateEmployeeData(HomeDTO objHomeDTO)
        {
            var xid = dbcontext.Employee.Where(r => r.Id == objHomeDTO.Id).FirstOrDefault();
            if(xid == null)
            {
                Response response = new Response()
                {
                    Message = "Id does not exist",
                    Status = false,
                    Data = null
                };

                return response;
            }
            else
            {
                Employee xemp = dbcontext.Employee.Where(r => r.Id == xid.Id).FirstOrDefault();
                xemp.FirstName = objHomeDTO.FirstName;
                xemp.LastName = objHomeDTO.LastName;
                xemp.Address = objHomeDTO.Address;
                xemp.IsStudent = objHomeDTO.IsStudent;
                dbcontext.Employee.Update(xemp);
                dbcontext.SaveChanges();
                Response response = new Response()
                {
                    Message = "Data is updated successfully..",
                    Status = true,
                    Data = new Array[0]
                };

                return response;
            }
        }

        public Response deleteEmployeeData(HomeDTO objHomeDTO)
        {
            var xid = dbcontext.Employee.Where(r => r.Id == objHomeDTO.Id).FirstOrDefault();
            if (xid == null)
            {
                Response response = new Response()
                {
                    Message = "Id does not exist",
                    Status = false,
                    Data = null
                };

                return response;
            }
            else
            {
                Employee xemp = dbcontext.Employee.Where(r => r.Id == xid.Id).FirstOrDefault();
                dbcontext.Employee.Remove(xemp);
                dbcontext.SaveChanges();
                Response response = new Response()
                {
                    Message = "Data is deleted successfully..",
                    Status = true,
                    Data = new Array[0]
                };
                return response;
            }
        }
    }
}
