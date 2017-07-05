using Desafio.model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Desafio
{

    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cliente_Id { get; set; }

        [StringLength(100)]
        public String Nome { get; set; }

        [StringLength(11)]
        public String Cpf { get; set; }

        [StringLength(10)]
        public String DataNascimento { get; set; }

        [StringLength(16)]
        public String NumCartao { get; set; }
    }
}