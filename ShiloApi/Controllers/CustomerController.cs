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
    [Route("[controller]")]
    [ApiController]
    public class KolCustomerController : ControllerBase
    {
        // An instance of data communication to the database
        public ShiloShopContext shopContext;
        public KolCustomerController(ShiloShopContext shopContext)
        {
            // A builder who initializes each instance of the class
            this.shopContext = shopContext;
        }
        [HttpGet("CustumerOrder/{ID}")]
        // Returns a list of all orders that belong to the ID card
        public ActionResult<List<Object>> GetCustOrd(string ID)
        {
            try
            {
                List<Orders> Or = new List<Orders>();
                foreach (Orders item in this.shopContext.Orders)
                    if(item.CustumerID!=null)
                    Or.Add(item);
                List<Prodacts> Pr = new List<Prodacts>();
                foreach (Prodacts item in this.shopContext.Prodacts)
                    Pr.Add(item);
                List<Object> list = new List<object>();
                // LINQ Question: Where there are orders with this ID will attach to the orders the customer's data
                //We will create a new object with specific data that is both in the order and in the customer's name
                var getList = from or in (Or.Where(
                                          o => o.CustumerID.Equals(ID)))
                              join pr in Pr
                              on or.prodactbandName equals pr.bandName
                              into table
                              select new { teble = table, ord = or };
                foreach (var item in getList)
                {

                    foreach (var i in item.teble)
                    {
                        var anoObj = new { date = item.ord.date, adres = item.ord.CustumerAddres, band = i.bandName, url = i.Link };
                        list.Add(anoObj);
                    }

                }
                return list;
            }
            catch
            {
                return NotFound(404);
            }

        }
        [HttpGet("Custumer")]
        // Give all clients in the database
        public ActionResult<List<Custumer>> GetCustumer()
        {
            try
            {
                List<Custumer> CustRez = new List<Custumer>();
                foreach (Custumer item in shopContext.Customers)
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
        [HttpPost("Custumer/{Custumer}")]
        // Add a new customer
        public ActionResult AddCustumer([FromForm] Custumer cust)
        {
            try
            {
                // Check if there is no such customer
                foreach (Custumer item in shopContext.Customers)
                {
                    if (cust.PasWord == item.PasWord && cust.email == item.email)
                        return NotFound(400);
                }
                this.shopContext.Customers.Add(cust);
                this.shopContext.SaveChanges();
                return Ok(202);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(400);
            }

        }
        // Delete the customer according to ID
        [HttpDelete("Custumer/Delete/{ID}")]
        public ActionResult<List<Custumer>> DeleteCust(string ID)
        {

            Custumer cust = new Custumer();
            Boolean match = false;
            try
            {
                // You will find the customer with the ID and delete it
                foreach (Custumer item in shopContext.Customers)
                {
                    if (item.CustumerID == ID)
                    {
                        match = true;
                        cust = item;
                        break;
                    }

                }

                if (match)
                {
                    shopContext.Customers.Remove(cust);
                    shopContext.SaveChanges();
                    return Ok(202);
                }
                else
                    return NotFound(404);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(404);
            }

        }
    }
}
