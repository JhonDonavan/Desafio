using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.model
{
    [Table("pagamentos")]
    public class Pagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double Valor { get; set; }

        [StringLength(10)]
        public String Data { get; set; }

        public int Cliente_Id { get; set; }

        public int Estabelecimento_Id { get; set; }

        [ForeignKey("Cliente_Id")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("Estabelecimento_Id")]
        public virtual Estabelecimento Estabelecimento { get; set; }
    }
}