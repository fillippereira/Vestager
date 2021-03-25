using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vestager.Domain.Entities
{
    [Table("Locacoes")]
    public class Locacao
    {
        [Key]
        public int LocacaoID { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual Cliente Cliente { get; set; }
        public int VestidoID { get; set; }
        [ForeignKey("VestidoID")]
        public virtual Vestido Vestido { get; set; }
        public double Valor { get; set; }
        public double Desconto { get; set; }
        public string FormaDePagamento { get; set; }
    }
}
