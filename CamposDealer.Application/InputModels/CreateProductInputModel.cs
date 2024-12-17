using System.ComponentModel.DataAnnotations;

namespace CamposDealer.Application.InputModels
{
    public class CreateProductInputModel
    {
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo descrição deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo descrição deve ter no máximo 100 caracteres")]
        public string Description { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public float ProductValue { get; set; }
    }
}
