namespace ConexionDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class Vehicle
    {
        public Vehicle()
        {
          
            DealerVehicleList = new List<DealerVehicle>();

        }

        [Key]
        public int Id { get; set; }

        public string Color { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public double Miles { get; set; }

        public virtual List<DealerVehicle> DealerVehicleList { get; set; }
    }
}
