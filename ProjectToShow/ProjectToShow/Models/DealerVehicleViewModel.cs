using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectToShow.Models
{
    public class DealerVehicleViewModel
    {
        public DealerVehicleViewModel()
        {

        }
        public int Id { get; set; }
        public int AmountVehicle { get; set; }

        public DateTime DateIng { get; set; }

        public DateTime DateOut { get; set; }

        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }

        [Display(Name = "Dealer")]
        public int DealerId { get; set; }


    }
}