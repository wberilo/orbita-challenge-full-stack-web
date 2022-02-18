using FluentValidation;
using FluentValidation.Results;
using OrbitaChallenge.Domain.Architecture;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitaChallenge.Domain.StudentAggregate
{
    public class Student : AuditableEntity
    {
        public Student(string nome, string email, string rA, string cPF)
        {
            Nome = nome;
            Email = email;
            RA = rA;
            CPF = cPF;
        }

        [Column("ra")]
        [Required]
        [Key]
        public string RA { get; init; }

        [Column("nome", TypeName = "varchar")]
        [Required]
        [MaxLength(250)]
        public string Nome { get; set; }

        [Column("email", TypeName = "varchar")]
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Column("cpf", TypeName = "varchar")]
        [Required]
        [MaxLength(11)]
        public string CPF { get; init; }
    }
}
