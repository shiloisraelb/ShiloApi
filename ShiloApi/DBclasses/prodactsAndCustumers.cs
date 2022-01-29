using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ClassLibrary1;

namespace ShiloApi
{
    //A parent class that inherits a method for applying polymorphism to heir classes
    public class IDats
    {
        //An overridden method that deletes in the database the date specific to the inheriting class
        public virtual void isdats(Object item) { }
    }
    //A class that creates a structure of a client's data
    public class Custumer 
    {
        
        [Key]//The customer's ID card is the primary key
        public string CustumerID { get; set; }
        public string name { get; set; }
        [EmailAddress]
        public string email { get; set; }

        public string PasWord { get; set; }
       
        public List<Orders> orders { get; set; }
    }
    //A class that creates a structure of a prudact's data
    public class Prodacts
    {
      
        [Key]//The bandName card is the primary key
        public string bandName { get; set; }
        public int conectionNumber { get; set; }
        public string instrument{ get; set; }
        public string Link { get; set; }
    }
    //A class that creates a structure of a Student's data
    public class Students : IDats
    {
       
        public string studentID { get; set; }
        [Key]//The student's date is the primary key
        public DateTime date { get; set; }
        public string Name { get; set; }
        public string instrument { get; set; }
        //An overridden method that deletes in the database the date specific to the inheriting class
        public override void isdats(Object item)
        {
            ShiloShopContext MyshopContext = new ShiloShopContext();
            Students stud = new Students();
            stud = (Students)item;
            MyshopContext.Students.Remove(stud);
            MyshopContext.SaveChanges();
        }
    }
    //A class that creates a structure of a Order's data
    public class Orders : IDats
    {
        public string CustumerID { get; set; }
        public Prodacts prodact { get; set; }
        [Key]//The order's date is the primary key
        public DateTime date { get; set; }
         
        public string prodactbandName { get; set; }
        public string CustumerAddres { get; set; }
        //An overridden method that deletes in the database the date specific to the inheriting class
        public override void isdats(Object item) 
        {
            ShiloShopContext MyshopContext = new ShiloShopContext();
            Orders stud = new Orders();
            stud = (Orders)item;
            MyshopContext.Orders.Remove(stud);
            MyshopContext.SaveChanges();
            
        }
    }
 
}
