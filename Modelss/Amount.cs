using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Amount:Entity
    {
        public decimal Amount_Value { get; set; }
        [ForeignKey("Buyer")]
        public int Buyer_ID { get; set; }
        public Buyer Buyer { get; set; }
        [JsonIgnore]
        [InverseProperty("Amount")]
        public ICollection<PossibleAmounts> PossibleAmounts { get; set; }
    }
}
