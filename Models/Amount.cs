using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Amount:Entity
    {
        public decimal Amount_Value { get; set; }
        [InverseProperty("Amount")]
        public ICollection<PossibleAmounts> PossibleAmounts { get; set; }
    }
}
