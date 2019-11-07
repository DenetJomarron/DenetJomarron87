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
    public class VehicleController : Controller
    {
        PDBContext dbContex = new PDBContext();
        // GET: Vehicle
        public ViewResult Index()
        {
            ViewBag.VehicleList = dbContex.Vehicles.ToList();

            return View();
        }

        // GET: Create Vehicle
        public ActionResult Create() 
        {
            VehicleViewModel model = new VehicleViewModel();


            return View(model);
        }

        // Post: Create Vehicle
        [HttpPost]
        public ActionResult Create(VehicleViewModel vehicle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Vehicle vehicleobj = dbContex.Vehicles.Find(vehicle.Id);
                    if (vehicleobj != null)
                    {
                        ModelState.AddModelError("", "The Vehicle was created.");
                    }
                    else
                    {
                        Vehicle newVehicle = vehicle.ToVehicle(vehicleobj);

                        dbContex.Vehicles.Add(newVehicle);
                        dbContex.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (RetryLimitExceededException)
            {
               
                ModelState.AddModelError("", "Unable to save changes. Try again, Please se Administrator.");
                throw;
            }


            return View(vehicle);
        }

        // Details Vehicle
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = dbContex.Vehicles.Find(Id);

            if (vehicle == null)
            {
                return HttpNotFound();

            }
            VehicleViewModel model = new VehicleViewModel(vehicle);
           
           return View(model);
        }

        // GET: Delete Vehicle
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
            Vehicle vehicle = dbContex.Vehicles.Find(id);

            if (vehicle == null)
            {
                return HttpNotFound();
            }

            DeleteVehicleViewModel model = new DeleteVehicleViewModel(vehicle);

            return View(model);
        }

        // POST:  Delete Vehicle
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Vehicle vehicleDeleted = dbContex.Vehicles.Find(id);
                dbContex.Vehicles.Remove(vehicleDeleted);
                dbContex.SaveChanges();
            }
            catch (RetryLimitExceededException)
            {
                
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        // GET: Edit Vehicle
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vehicle vehicle = dbContex.Vehicles.Find(id);

            if(vehicle == null)
            {
                return HttpNotFound();
            }
           
            VehicleViewModel model = new VehicleViewModel(vehicle);
            return View(model);
        }

        // POST: Edit Person
        [HttpPost]
        public ActionResult Edit(VehicleViewModel vehicle)
        {
            var vehileToUpdate = dbContex.Vehicles.Find(vehicle.Id);
            Vehicle vehileNew = vehicle.ToVehicle(vehileToUpdate);

            if (vehileToUpdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            if (ModelState.IsValid)
            {
                try
                {

                    dbContex.Vehicles.Attach(vehileNew);
                    dbContex.Entry(vehileNew).State = EntityState.Modified;
                    dbContex.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {

                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            VehicleViewModel model = new VehicleViewModel(vehileNew);
            return View(model);
        }

        public ActionResult Information()
        {
            ViewBag.Message = "Car Help Information";

            return View();
        }
    }

}