﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockManagementMvcWebApp.Manager;
using StockManagementMvcWebApp.Models;
using StockManagementMvcWebApp.Models.View;

namespace StockManagementMvcWebApp.Controllers
{
    public class StockController : Controller
    {
        CompanyManager aCompanyManager = new CompanyManager();
        ItemManager aItemManager = new ItemManager();
        StockManager aStockManager = new StockManager();

        [HttpGet]
        public ActionResult StockInSave()
        {
            ViewBag.Companies = aCompanyManager.GetAllCompanies();
            ViewBag.Items = aItemManager.GetAllItems();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StockInSave(StockIn stockIn)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                message = aStockManager.SaveStockIn(stockIn);
                ViewBag.Message = message;
            }
            ViewBag.Companies = aCompanyManager.GetAllCompanies();
            ViewBag.Items = aItemManager.GetAllItems();

            return View();
        }

        public ActionResult GetItemsById(int itemId)
        {
            List<Item> items = aItemManager.GetAllItems();
            var i = items.Where(p => p.ItemId == itemId);
            return Json(i);
        }

        public ActionResult GetItemsByCompanyId(int companyId)
        {
            List<Item> items = aItemManager.GetAllItems();
            var c = items.Where(p => p.CompanyId == companyId);
            return Json(c);
        }

        [HttpGet]
        public ActionResult StockOutSave()
        {
            ViewBag.Companies = aCompanyManager.GetAllCompanies();
            ViewBag.Items = aItemManager.GetAllItems();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StockOutSave(StockOut stockOut)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                //message = aStockManager.SaveStockOut(stockOut);
                ViewBag.Message = message;
            }
            ViewBag.Companies = aCompanyManager.GetAllCompanies();
            ViewBag.Items = aItemManager.GetAllItems();
            return View();
        }

//        public ActionResult GetStockInfoById(int id)
//        {
//            List<StockSummary> stockSummaries = aStockManager.GetStockInformation();
//            var stocks = stockSummaries.Where(s => s.);
//            return Json(stocks);
//        }

        
    }
}