using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Buyer:Entity
    {
        public string Name { get; set; }
        public int ZipCode { get; set; }
        [InverseProperty("Buyer")]
        public ICollection<Amount> Amounts { get; set; }

    }
}
