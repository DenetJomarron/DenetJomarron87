namespace ConexionDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class Dealer
    {

        public  Dealer()
        {
             DealerPersonList = new List<DealerPerson>();
            DealerVehicleList = new List<DealerVehicle>();

        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string DealerNumber { get; set; }

        public string ManagerName { get; set; }

        public string ManagerId { get; set; }

        public virtual List<DealerPerson> DealerPersonList { get; set; }

        public virtual List<DealerVehicle> DealerVehicleList { get; set; }

    }
}
