﻿using System.ComponentModel.DataAnnotations;

namespace Gestor.Helpers.Models.EstablishmentDtos
{
    public class CreateEstablishmentDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Description { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "Tamanho inválido")]
        public string OwnerId { get; set; }

        public string LogoFilePath { get; set; } = "";

        public bool IsOpen { get; set; } = false;

        public string Address { get; set; } = "";

        public string Url { get; set; } = "";

        public string PixKey { get; set; } = "";

        public string Instagram { get; set; } = string.Empty;
        public string Whatsapp { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
