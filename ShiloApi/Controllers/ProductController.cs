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
    public class KolProductController : ControllerBase
    {
        // An instance of data communication to the database
        public ShiloShopContext shopContext;
        public KolProductController(ShiloShopContext shopContext)
        {
            // A builder who initializes each instance of the class
            this.shopContext = shopContext;
        }

        // Give all Prodacts in the database
        [HttpGet("Prodacts")]
        public ActionResult<List<Prodacts>> GetProdacts()
        {
            try
            {
                List<Prodacts> CustRez = new List<Prodacts>();
                foreach (Prodacts item in shopContext.Prodacts)
                {
                    CustRez.Add(item);
                }
                return CustRez;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Ok("empty");
            }

        }

        // Add a new product
        [HttpPost("Prodacts/{Prodacts}")]
        public ActionResult<List<Prodacts>> AddProdacts([FromForm] Prodacts pust)
        {
            try
            {
                shopContext.Prodacts.Add(pust);
                shopContext.SaveChanges();
                return Ok(202);

            }
            catch
            {
                return NotFound(404);
            }

        }

        // Update Product

        [HttpPut("Prodacts/Update/{pust}")]
        public ActionResult<List<Prodacts>> UpdateProdacts([FromForm] Prodacts pust)
        {
            try
            {
                // Delete the product and create another update
                bool pr = false;
                Prodacts itemP = new Prodacts();
                foreach (Prodacts item in shopContext.Prodacts)
                {
                    if (item.bandName == pust.bandName)
                    {
                        pr = true;
                        itemP = item;
                        break;
                    }
                }
                if (pr)
                {
                    shopContext.Prodacts.Remove(itemP);
                    shopContext.SaveChanges();
                    shopContext.Prodacts.Add(pust);
                    shopContext.SaveChanges();
                    return Ok(202);
                }
                else
                {
                    return NotFound(404);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(404);
            }

        }

        [HttpDelete("Prodacts/Delete")]
        // Delete the product
        public ActionResult<List<Prodacts>> DeleteProdacts([FromForm] Prodacts pust)
        {
            try
            {
                // You will find the product name and delete it
                foreach (Prodacts item in shopContext.Prodacts)
                {
                    if (item.bandName == pust.bandName)
                    {
                        shopContext.Prodacts.Remove(pust);
                        shopContext.SaveChanges();
                        return Ok("Deleted");
                    }
                }
                return Ok("this is not corect ID");
            }
            catch
            {
                return Ok("empty");
            }

        }
    }
}
