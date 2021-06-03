using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SModel;
using SBL;
using BakeryWebUI.Models;
namespace BakeryWebUI.Controllers
{
    public class OrderController : Controller
    {
        private ICustomerBL _custBL;
        private IOrderBL _orderBL;

        public OrderController(ICustomerBL custBL, IOrderBL orderBL)
        {
            _custBL = custBL;
            _orderBL = orderBL;
        }
        // GET: OrderController
        public ActionResult Index(int id)
        {
            ViewBag.cust = _custBL.GetCustomerById(id);

            List<Orders> orderList = _orderBL.GetOrders(_custBL.GetCustomerById(id));
            foreach(Orders o in orderList)
            {
                 Debug.WriteLine(o.Loaf);
            }

            return View(orderList
                   .Select(Orders => new OrderVM(Orders))
                   .ToList());
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create(int id)
        {
            return View(new OrderVM(id));
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM model)
        {
            Debug.WriteLine(_orderBL.GetBread(model.BreadSelection).Breadtype);
            Debug.WriteLine(_orderBL.GetBread(model.BreadSelection));
            try
            {
                


                if (ModelState.IsValid)
                {
                    _orderBL.AddOrder(_custBL.GetCustomerById(model.CustomerId), new Orders
                    {
                        Id = model.Id,
                        CustomerId = model.CustomerId,
                        Loaf = _orderBL.GetBread(model.BreadSelection),
                        BreadCount = model.BreadCount
                    }, model.LocationSelection);
                    return RedirectToAction(nameof(Index), new { id = model.CustomerId});
                }
                return View(model);
            }
            catch
            {
                Debug.WriteLine("Error");
                return View(model);
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
