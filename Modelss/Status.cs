using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Status:Entity
    {
        public DateTime? status_date { get; set; }
        
        [InverseProperty("Status")]
        public ICollection<Previous_Status> Previous_Statuses { get; set; }

    }
}
