using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreEFCoreExample.Models
{
    public class Category
    {
        public Category()
        {
        }

        public int Id { get; set; }
        [ForeignKey(nameof(Element))]
        public int ElementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Element Element { get; set; }
    }
}
