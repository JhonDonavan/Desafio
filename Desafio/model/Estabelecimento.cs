using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Desafio.model
{
    [Table("estabelecimentos")]
    public class Estabelecimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Estabelecimento_Id { get; set; }

        [StringLength(200)]
        public String Nome { get; set; }

        [StringLength(18)]
        public String Cnpj { get; set; }

        [StringLength(200)]
        public String Natureza_Juridica { get; set; }

        [StringLength(200)]
        public String Situacao { get; set; }

    }
}