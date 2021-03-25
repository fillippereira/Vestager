using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Vestager.Domain.Entities;

namespace Vestager.Domain.Entities
{
    public class Prova
    {
        [Key]
        public int ProvaID { get; set; }
        public int ClienteID { get; set; }
        [ForeignKey("ClienteID")]
        public virtual Cliente Cliente { get; set; }
        public DateTime DataProva { get; set; }
        public virtual List<Ajuste> Ajustes { get; set; }
    }
}
