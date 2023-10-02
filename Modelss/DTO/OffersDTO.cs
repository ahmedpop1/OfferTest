using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class OffersDTO
    {
        public int OfferID { get; set; }
        public DateTime OfferDate { get; set; }
        public string CurrentBuyer { get; set; }
        public decimal CurrentAmount { get; set; }
        public int CurrentStatusID { get; set; }
    }
}
