using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_NET_5.Models
{
    public class ApplicationType
    {
        [Key]
        [Column("ApplicationTypeId")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
