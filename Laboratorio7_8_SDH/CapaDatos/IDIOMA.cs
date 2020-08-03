using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class IDIOMA
    {
        [Key]
        [Column(Order = 0)]
        
        public int ID_IDIOMA { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        
        public string DESC_IDIOMA { get; set; }

    }
}
