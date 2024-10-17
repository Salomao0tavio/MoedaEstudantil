﻿using System.ComponentModel.DataAnnotations;

namespace MoedaEstudantil.Entities
{
    public abstract class Pessoa
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(11)]
        ///RG ou CPF
        public string Documento { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
