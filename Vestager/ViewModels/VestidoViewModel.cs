using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vestager.MVC.Models
{
    public class VestidoViewModel
    {   
        public int VestidoID { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Tamanho { get; set; }
        [DisplayName("Preço Sugerido")]
        public double PrecoSugerido { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DisplayName("Tipo do Vestido")]
        public int TipoVestido { get; set; }
        public string UrlVestido { get; set; }
    }
}
