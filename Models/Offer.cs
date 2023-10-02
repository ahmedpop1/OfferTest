using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Offer: Entity
    {
        public DateTime date { get; set; }
        [InverseProperty("Offer")]
        public ICollection<Previous_Status> Previous_Statuses { get; set; }
        [InverseProperty("Offer")]
        public ICollection<PossibleAmounts> PossibleAmounts { get; set; }


    }
}
