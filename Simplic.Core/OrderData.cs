using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.Core
{
    public class OrderData
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [MaxLength(160)]
        public string Description { get; set; }
        public int PersonID { get; set; }
    }
}
