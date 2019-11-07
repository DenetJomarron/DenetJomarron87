using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConexionDb
{
    public class DealerPerson
    {
        [Key]
        public int Id { get; set; }

        public DateTime ContractDate { get; set; }

        //Document List 
        public decimal  AmountStarPayment { get; set; }

        [Column(Order = 1)]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Column(Order = 2)]
        public int DealerId { get; set; }
        [ForeignKey("DealerId")]
        public virtual Dealer Dealer { get; set; }

      


    }
}