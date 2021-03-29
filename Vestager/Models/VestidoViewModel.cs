using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vestager.MVC.Models
{
    public class VestidoViewModel
    {   
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Tamanho { get; set; }
        public string Descricao { get; set; }
        public int TipoVestido { get; set; }
    }
}
