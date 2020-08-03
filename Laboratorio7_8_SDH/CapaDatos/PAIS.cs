using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class PAIS
    {
        [Key]
        [Column(Order = 0)]
        public int ID_PAIS { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
       
        public string DESCRIPCION { get; set; }

        
    }
}
