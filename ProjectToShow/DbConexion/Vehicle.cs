namespace DbConexion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vehicle
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public double Miles { get; set; }

        public int IdDealer { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
