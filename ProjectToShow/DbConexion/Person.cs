namespace DbConexion
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public string Sexo { get; set; }

        public string UserId { get; set; }

        public DateTime CreateDate { get; set; }

        public int IdDealer { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}
