using ConexionDb;
using ProjectToShow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectToShow.Controllers
{     
    public class UserAccountController : Controller
    {
        private PDBContext dbContext = new PDBContext();

        // GET: UserAccount
        public ActionResult Index()
        {
            ViewBag.UserList = dbContext.UserAccount.ToList();
            return View();
        }

        // GET: Register
        public ActionResult Register()
        {
            UserAccountViewModel model = new UserAccountViewModel();
              ViewBag.Info = false;
            return View();


        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(UserAccountViewModel userAccountModel)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    UserAccount userAccountObj = dbContext.UserAccount.Find(userAccountModel.UserId);
                    if(userAccountObj != null)
                    {
                        ModelState.AddModelError("","The Account was created");
                        
                    }
                    else
                    {

                       UserAccount userAccountNewObj = userAccountModel.ToUserAccount(userAccountObj);
                        dbContext.UserAccount.Add(userAccountNewObj);
                        dbContext.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = userAccountModel.FirstName + " " + userAccountModel.LastName + "succefully register. ";
                    }
                   
                }
                catch (RetryLimitExceededException)
                {

                    ModelState.AddModelError("", "Unable to save changes. Try again, Please se Administrator.");
                }
               
            }


            return RedirectToAction("LogIn");


        }


        // GET: Log in
        public ActionResult LogIn()
        {
            ViewBag.Info = false;
            return View();
        }
       // POST: LogIn
        [HttpPost]
        public ActionResult LogIn( LogInViewModel userLogInModel)
        {
            if (ModelState.IsValid)
            {

                //var user = dbContext.UserAccount.Single(u => u.UserName == userLogInModel.UserName && u.Password == userLogInModel.Password);
                var user = dbContext.UserAccount.Where(u => u.UserName.Equals(userLogInModel.UserName) && u.Password.Equals(userLogInModel.Password)).FirstOrDefault();
                if (user != null)
                {
                    Session["UserId"] = user.UserId.ToString();
                    Session["UserName"] = user.UserName.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "UseName or Password is wrong");
                }
            }
                return View();
        }

        public ActionResult LoggedIn() 
        {
          if(Session["UserId"] != null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        
        }

    }
}