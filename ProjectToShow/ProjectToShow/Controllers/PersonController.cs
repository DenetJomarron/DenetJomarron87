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
    public class PersonController : Controller
    {
       
        private PDBContext dbContext = new PDBContext();

        // GET:  Index Person
        public ViewResult Index()
        {        
            ViewBag.list = dbContext.People.ToList();
            
            return View();
        }

        // GET: Create Person
        public ActionResult Create()
        {
            List<SelectListItem> sexoList = new List<SelectListItem>();
            sexoList.Add(new SelectListItem() { Text = "Female", Value = "Female" });
            sexoList.Add(new SelectListItem() { Text = "Male", Value = "Male" });
            ViewBag.SexoInformation = new SelectList(sexoList, "Value", "Text");
                    
            return View();
        }

        // POST: Create Person
        [HttpPost]       
        public ActionResult Create(PersonViewModel personModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Person personObj = dbContext.People.Find(personModel.Id);
                    if (personObj != null)
                    {
                        ModelState.AddModelError("", "The Person was created.");
                    }
                    else
                    {
                        Person newPerson = personModel.ToPerson(personObj);
                        dbContext.People.Add(newPerson);
                        dbContext.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (RetryLimitExceededException )
            {
               
                ModelState.AddModelError("", "Unable to save changes. Try again, Please se Administrator.");
            }
            return View(personModel);
        }

        // Details Person
        public ActionResult Details(int? id)
        {
             
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = dbContext.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            PersonViewModel model = new PersonViewModel(person);
                      
            return View(model);
        }

        // GET: Delete Person
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
            Person person = dbContext.People.Find(id);

            if (person == null)
            {
                return HttpNotFound();
            }
           
            DeletePersonViewModel model = new DeletePersonViewModel(person);
            
            return View(model);
        }

        // POST: Person/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Person people = dbContext.People.Find(id);
                dbContext.People.Remove(people);
                dbContext.SaveChanges();
            }
            catch (RetryLimitExceededException)
            {
              
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        // GET: Edit Person        
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> sexoList = new List<SelectListItem>();
            sexoList.Add(new SelectListItem() { Text = "Female", Value = "Female" });
            sexoList.Add(new SelectListItem() { Text = "Male", Value = "Male" });
            ViewBag.SexoInformation = new SelectList(sexoList, "Value", "Text");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = dbContext.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            PersonViewModel model = new PersonViewModel(person);
            return View(model);
        }

        // POST: Edit Person
        [HttpPost]
        public ActionResult Edit(PersonViewModel person)
        {
            var personToUpdate = dbContext.People.Find(person.Id);
            if (personToUpdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    personToUpdate.Name = person.Name;
                    personToUpdate.LastName = person.LastName;
                    personToUpdate.Age = person.Age;
                    personToUpdate.Phone = person.Phone;
                    personToUpdate.Sexo = person.Sexo;

                    dbContext.People.Attach(personToUpdate);
                    dbContext.Entry(personToUpdate).State = EntityState.Modified;
                    dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException )
                {
                   
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PersonViewModel model = new PersonViewModel(personToUpdate);
            return View(model);
        }

      }
}