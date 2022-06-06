using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Base;

namespace Domain.Entities.Tags
{
    public partial class Tag: AuditEntity<int>
    {
        [Required] 
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
    }
}
