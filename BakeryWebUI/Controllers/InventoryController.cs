using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBL;
using SModel;
using BakeryWebUI.Models;

namespace BakeryWebUI.Controllers
{
    public class InventoryController : Controller
    {
        private IOrderBL _ordBL;
        public InventoryController(IOrderBL oBL)
        {
            _ordBL = oBL;
        }
        
        // GET: InventoryController
        public ActionResult Index(int id)
        {
            return View(_ordBL.GetBakeryInvertory(id)
                .Select(inv =>
                new InventoryVM(inv.Breadtype, inv.Stock, inv.BreadId))
                .ToList());
        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: InventoryController/Edit/5
        public ActionResult Edit(string bread, int id)
        {
            Bread i = _ordBL.GetBread(bread);
            return View(i);
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bread bread)
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

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
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
