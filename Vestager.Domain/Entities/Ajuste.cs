﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vestager.Domain.Entities
{
    public class Ajuste
    {   [Key]
        public int AjusteID { get; set; }
        public  string Nome { get; set; }
        public int Nivel { get; set; }
        public DateTime TempoEstimado { get; set; }
    }
}
