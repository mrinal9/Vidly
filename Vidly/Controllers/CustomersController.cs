using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {


            var cusList = getCustomers();
            
            return View(cusList);
        }

       
        public ActionResult Details(int id)
        {
            var cusList = getCustomers();
           var customer= cusList.SingleOrDefault(x => x.CustomerId == id);
            if (customer == null)
                return HttpNotFound();

           return View(customer);
        }

        private IEnumerable<Customer> getCustomers()
        {
            return new List<Customer>
                {
                    new Customer {CustomerId = 1, CustomerName = "Mrinal"},
                    new Customer {CustomerId = 2, CustomerName = "Neha"}
                };
        }
    }
}