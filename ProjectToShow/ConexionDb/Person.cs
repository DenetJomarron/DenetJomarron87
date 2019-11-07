namespace ConexionDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class Person
    {
        public Person()
        {
            DealerPersonList = new List<DealerPerson>();
           
        }

        [Key]
        public int Id { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public string Sexo { get; set; }

        public virtual List<DealerPerson> DealerPersonList { get; set; }


    }
}
