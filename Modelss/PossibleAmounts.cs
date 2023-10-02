using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class PossibleAmounts : Entity
    {
        [JsonIgnore]
        public Offer Offer { get; set; }
        [ForeignKey("Offer")]
        public int OfferID { get; set; }
        public Amount Amount { get; set; }
        [ForeignKey("Amount")]
        public int AmountID { get; set; }
        public bool IsActive { get; set; }
    }
}
