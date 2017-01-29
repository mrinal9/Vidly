using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var cusList = _context.Customers.Include(c=>c.MembershipType);
            
            return View(cusList);
        }


        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).ToList().SingleOrDefault(x => x.CustomerId == id);   
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var viewModel = new CustomerDetailsViewModel
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerDetails",viewModel);
        }
        public ActionResult Edit(int id)
        {
            var viewModel = new CustomerDetailsViewModel
            {
                Customer = _context.Customers.SingleOrDefault(c=>c.CustomerId==id),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerDetails",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var customerMembershipType = new CustomerDetailsViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerDetails", customerMembershipType);
            }

            if(customer.CustomerId==0)
            _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.CustomerId == customer.CustomerId);
                if (customerInDb == null)
                    return HttpNotFound();
                customerInDb.CustomerName = customer.CustomerName;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedTonewsLetter = customer.IsSubscribedTonewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("index","customers");
        }

       
    }
}