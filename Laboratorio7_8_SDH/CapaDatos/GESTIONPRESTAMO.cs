using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GESTIONPRESTAMO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_GESTION { get; set; }

        [Column(Order = 1)]
        public int ID_PAIS { get; set; }

                            

        [Column(Order = 2)]
        public int CANT_HABIT { get; set; }

        [Column(Order = 3)]
        public int ID_IDIOMA { get; set; }

               
                
        [Column(Order = 4)]
        public double PIB { get; set; }

        [Column(Order = 5)]
        
        public double SUPERFICIE { get; set; }


        [Column(Order = 6)]
        public string RIESGO { get; set; }
        

        [Column(Order = 7)]
        
        public int PRESTAMO { get; set; }
    }
}
