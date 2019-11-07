using ConexionDb;
using ProjectToShow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectToShow.Controllers
{
    public class DealerController : Controller
    {
        private PDBContext dbContext = new PDBContext();
        // GET: Dealer
        public ViewResult Index()
        {
            ViewBag.list = dbContext.Dealers.ToList();

            return View();
        }
        //Get:Create Dealer
        public ActionResult Create()
        {
            DealerViewModel model = new DealerViewModel();


            return View(model);
        }

        //Post:Create Dealer
        [HttpPost]
        public ActionResult Create(DealerViewModel dealerModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Dealer dealerObj = dbContext.Dealers.Find(dealerModel.Id);
                    if (dealerObj != null)
                    {
                        ModelState.AddModelError("", "The Dealer was created.");
                    }
                    else
                    {
                        Dealer dealerSave = dealerModel.ToDealer(dealerObj);

                        dbContext.Dealers.Add(dealerSave);
                        dbContext.SaveChanges();
                        return RedirectToAction("Index");
                       
                    }
                }

            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, Please se Administrator.");
            }


            return View(dealerModel);
        }


        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dealer dealers = dbContext.Dealers.Find(Id);

            if (dealers == null)
            {
                return HttpNotFound();

            }
            DealerViewModel model = new DealerViewModel(dealers);

            return View(model);
        }

        // GET: Delete Dealer
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Dealer dealer = dbContext.Dealers.Find(id);

            if (dealer == null)
            {
                return HttpNotFound();
            }

            DeleteDealerViewModel model = new DeleteDealerViewModel(dealer);

            return View(model);
        }

        // POST:  Delete Dealer
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Dealer dealerDeleted = dbContext.Dealers.Find(id);
                dbContext.Dealers.Remove(dealerDeleted);
                dbContext.SaveChanges();
            }
            catch (RetryLimitExceededException)
            {

                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        // GET: Edit Dealer
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Dealer dealer = dbContext.Dealers.Find(id);

            if (dealer == null)
            {
                return HttpNotFound();
            }

            DealerViewModel model = new DealerViewModel(dealer);
            return View(model);
        }

        // POST: Edit Dealer
        [HttpPost]
        public ActionResult Edit(DealerViewModel dealerModel)
        {
            var dealerToUpdate = dbContext.Dealers.Find(dealerModel.Id);
            Dealer dealerNew = dealerModel.ToDealer(dealerToUpdate);

            if (dealerToUpdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            if (ModelState.IsValid)
            {
                try
                {

                    dbContext.Dealers.Attach(dealerNew);
                    dbContext.Entry(dealerNew).State = EntityState.Modified;
                    dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {

                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            DealerViewModel model = new DealerViewModel(dealerNew);
            return View(model);
        }

    }
}