using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ShiloApi.Controllers
{
    [EnableCors("shilo")]
    [ApiController]
    [Route("[controller]")]
    public class KolStudentController : ControllerBase
    {

        // An instance of data communication to the database
        public ShiloShopContext shopContext;
        public KolStudentController(ShiloShopContext shopContext)
        {
            // A builder who initializes each instance of the class
            this.shopContext = shopContext;
        }


        [HttpGet("Dats")]
        // Creates an instance of a list of orders and students from the database
        //whose basis is a date by which a diary was built
        public async Task<ActionResult<List<Object>>> GetDats()
        {
            try
            {


                List<Object> dats = new List<Object>();
                await foreach (Students item in this.shopContext.Students)
                    dats.Add(item);
                await foreach (Orders item in this.shopContext.Orders)
                    dats.Add(item);

                return dats;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(404);
            }
        }

        // Give all students in the database
        [HttpGet("Students")]
        public ActionResult<List<Students>> GetStudents()
        {
            try
            {
                List<Students> CustRez = new List<Students>();
                foreach (Students item in shopContext.Students)
                {
                    CustRez.Add(item);
                }
                return CustRez;
            }
            catch
            {
                return Ok("empty");
            }

        }

        [HttpPost("Students/{Students}")]
        // Add a new student
        public ActionResult<List<Students>> AddStudents([FromForm] Students cust)
        {
            try
            {
                // Check if there is no such date
                foreach (Students item in shopContext.Students)
                {

                    if (cust.date == item.date)
                        return NotFound("try egen");

                }
                foreach (Orders item in shopContext.Orders)
                {

                    if (cust.date == item.date)
                        return NotFound(404);

                }
                shopContext.Students.Add(cust);
                shopContext.SaveChanges();
                return Ok(202);
            }
            catch
            {
                return NotFound(404);
            }

        }

        [HttpDelete("Date/Delete/{Date}")]
        // Delete the order or student by date
        public async Task<ActionResult<string>> DeleteStudents(DateTime date)
        {
            try
            {
                // Find where the date is in the order or student and delete it by using a method whose name 
                //holds both the order instance and the student merge instance
                bool match = false;
                // Build an IDATE instance that would be generic to accept either student or order
                IDats obj = new IDats();
                await foreach (Students item in this.shopContext.Students)
                {
                    if (date == item.date)
                    {
                        match = true;
                        obj = new Students();
                        obj = item;
                        break;
                    }
                }


                await foreach (Orders item in this.shopContext.Orders)
                {

                    if (date == item.date)
                    {
                        match = true;
                        obj = new Orders();
                        obj = item;
                        break;
                    }
                }

                if (match)
                    obj.isdats(obj);
                return Ok(202);

            }
            catch (Exception e)
            {
                return NotFound(404);
            }

        }
    }
}
