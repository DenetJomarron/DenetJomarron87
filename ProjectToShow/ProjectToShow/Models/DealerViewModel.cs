using ConexionDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectToShow.Models
{
    public class DealerViewModel
    {
        public DealerViewModel ()
        {
        }

        public DealerViewModel(Dealer dealerObj)
        {
            if (dealerObj == null)
            {
                dealerObj = new Dealer();
            }
            Id = dealerObj.Id;
            Name = dealerObj.Name;
            DealerNumber = dealerObj.DealerNumber;
            ManagerId = dealerObj.ManagerId;
            ManagerName = dealerObj.ManagerName;
           

        }


        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Dealer#")]
        public string DealerNumber { get; set; }

        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }

        [Display(Name = "Manager Id")]
        public string ManagerId { get; set; }


        public Dealer ToDealer(Dealer dealerObj)
        {
            if (dealerObj == null)
            {
                dealerObj = new Dealer();
            }


            dealerObj.Id = Id;
            dealerObj.Name = Name;
            dealerObj.DealerNumber = DealerNumber;
            dealerObj.ManagerId = ManagerId;
            dealerObj.ManagerName = ManagerName;
            
            return dealerObj;
        }

     
    }

    public class DeleteDealerViewModel
    {

        public DeleteDealerViewModel()
        {
        }
        public DeleteDealerViewModel(Dealer dealer)
        {
            if (dealer == null)
            {
                dealer = new Dealer();
            }

            Id = dealer.Id;
            Name = dealer.Name;
            DealerNumber = dealer.DealerNumber;
            ManagerName = dealer.ManagerName;
            ManagerId = dealer.ManagerId;

        }

        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Dealer #")]
        public string DealerNumber { get; set; }

        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }

        [Display(Name = "Manager Id")]
        public string ManagerId { get; set; }



    }
}