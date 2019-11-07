using ConexionDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectToShow.Models
{
    public class UserAccountViewModel
    {
        public UserAccountViewModel()
        {

        }
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "Please Confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm PassWord")]
        public string ConfirmPassWord { get; set; }

        public UserAccount ToUserAccount(UserAccount userAccountObj) 
        {
            if (userAccountObj == null)
            {
                userAccountObj = new UserAccount();
            }

            userAccountObj.UserId = UserId;
            userAccountObj.FirstName = FirstName;
            userAccountObj.LastName = LastName;
            userAccountObj.Email = Email;
            userAccountObj.UserName = UserName;
            userAccountObj.Password = Password;
            userAccountObj.ConfirmPassWord = ConfirmPassWord;

            return userAccountObj;
        }


        
    }

    public class LogInViewModel
    {

        public LogInViewModel()
        {

        }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }




    }

}