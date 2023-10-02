using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Previous_Status:Entity
    {
        [JsonIgnore]
        public Offer Offer { get; set; }
        [ForeignKey("Offer")]
        public int OfferID { get; set; }
        public Status Status { get; set; }
        [ForeignKey("Status")]
        public int StatusID { get; set; }
        public bool IsActive { get; set; }

    }
}
