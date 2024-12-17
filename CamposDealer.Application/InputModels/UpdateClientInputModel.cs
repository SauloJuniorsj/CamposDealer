﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CamposDealer.Application.InputModels
{
    public class UpdateClientInputModel
    {
        public UpdateClientInputModel()
        {
            
        }
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo Nome deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        [Display(Name = "Cidade")]
        [MinLength(3, ErrorMessage = "O campo Cidade deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Cidade deve ter no máximo 100 caracteres")]
        public string City { get; set; }
    }
}
