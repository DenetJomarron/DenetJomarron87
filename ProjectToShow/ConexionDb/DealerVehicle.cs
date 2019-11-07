using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConexionDb
{
    public class DealerVehicle
    {
        [Key]
        public int Id { get; set; }
        public int AmountVehicle { get; set; }

        public DateTime DateIng { get; set; }

        public DateTime DateOut { get; set; }

        //Amount by Vehicle Type


        [Column(Order = 1)]
        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }

        [Column(Order = 2)]
        public int DealerId { get; set; }
        [ForeignKey("DealerId")]
        public virtual Dealer Dealer { get; set; }

    }
}