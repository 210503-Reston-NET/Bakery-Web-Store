using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBL;
using SModel;
using BakeryWebUI.Models;
namespace BakeryWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBL _custBL;

        public CustomerController(ICustomerBL cBL)
        {
            _custBL = cBL;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_custBL.GetAllCustomers()
                .Select(customer =>
                new CustomerVM(customer))
                .ToList());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerVM custVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _custBL.AddCustomer(new Customer
                    {
                        Id = custVM.Id,
                        FirstName = custVM.FirstName,
                        LastName = custVM.LastName
                    });
                    return RedirectToAction(nameof(Index));
                }
                return View(custVM);
            }
            catch
            {
                return View(custVM);
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new CustomerVM(_custBL.GetCustomerById(id)));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
