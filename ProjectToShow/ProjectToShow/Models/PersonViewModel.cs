using ConexionDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectToShow.Models
{
    public class PersonViewModel
    {
       public PersonViewModel()
        {

        }
       public PersonViewModel(Person person)
        {
            if (person == null)
            {
                Person newperson = new Person();
            }
            Name = person.Name;
            LastName = person.LastName;
            Age = person.Age;
            Id = person.Id;
            Sexo = person.Sexo;
            Phone = person.Phone;
            Code = person.Code;


        }
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Sex")]
        public string Sexo { get; set; }
        [Display(Name = "Last 4 Number of Social")]
        public int Code { get; set; }

        public Person ToPerson(Person PersonObj)
        {
            if (PersonObj == null)
            {
                PersonObj = new Person();
            }
            

                PersonObj.Id = Id;
                PersonObj.Name = Name;
                PersonObj.LastName = LastName;
                PersonObj.Age = Age;
                PersonObj.Phone = Phone;
                PersonObj.Sexo = Sexo;
                PersonObj.Code = Code;


            return PersonObj;
        }

    }
    public class DeletePersonViewModel
    {
        public DeletePersonViewModel()
        {

        }
        public DeletePersonViewModel(Person person)
        {
          
            Name = person.Name;
            LastName = person.LastName;
            Age = person.Age;
            Id = person.Id;
            Sexo = person.Sexo;
            Phone = person.Phone;
            Code = person.Code;

        }
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Sex")]
        public string Sexo { get; set; }

        public int Code { get; set; }

    }
}