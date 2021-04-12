using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vestager.Domain.Entities
{
    public abstract class Vestido
    {
        [Key]
        public int VestidoID { get; set; }
        public string Nome { get; set; }
        public string  Cor { get; set; }
        public string Tamanho { get; set; }
        public string Descricao { get; set; }
        public double PrecoSugerido { get; set; }
        public string UrlVestido { get; set; }

        public abstract string GetCaracteristicas();

        [DisplayName("Tipo Vestido")]
        public abstract string TipoVestido { get;  }
    }

    public class VestidoLongo : Vestido
    {
        public override string GetCaracteristicas()
        {
            return "Barra longa";
        }
        public override string TipoVestido
        {
            get
            {
                return "Vestido Longo";

            }
        }
    }
    public class VestidoCurto : Vestido
    {
        public override string GetCaracteristicas()
        {
            return "Barra Curta";
        }
        public override string TipoVestido
        {
            get
            {
                return "Vestido Curto";

            }
        }
    }
}
