using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorio2.Entidades
{
    public class persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }

        [StringLength(50)]
        public string NombrePersona { get; set; }

        public int EdadPersona { get; set; }

        [StringLength(50)]
        public string DescripcionPersona { get; set; }
    }
}
