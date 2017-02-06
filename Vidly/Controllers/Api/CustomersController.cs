using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context  =new ApplicationDbContext();
        }

        //Get Api/Customers
        public IHttpActionResult GetCustomers()
        {

            return Ok(_context.Customers
                      .Include(c=>c.MembershipType)
                      .ToList()
                      .Select(Mapper.Map<Customer, CustomerDto>));

        }

        //Get Api/Customers/Id
        public IHttpActionResult GetCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb==null)
            {
               return NotFound();
            }
            return Ok(customerInDb);

        }

        //Post Api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();}
           var customerEntity= Mapper.Map<CustomerDto, Customer>(customer);
            _context.Customers.Add(customerEntity);
            _context.SaveChanges();
            customer.CustomerId = customerEntity.CustomerId;
            return Created(new Uri(Request.RequestUri+"/"+ customer.CustomerId), customer);

        }

        //Put Api/Customers/Id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb == null)
                return NotFound();
             Mapper.Map(customer,customerInDb);
            _context.SaveChanges();
           
            return Ok();

        }

        //Delete Api/Customers/Id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb == null)
                return NotFound();
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
