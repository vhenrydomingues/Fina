using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Requests.Categories
{
    public class UpdateCategoryRequest : Request
    {
        [Required(ErrorMessage = "Titulo Invalido")]
        [MaxLength(80,ErrorMessage ="O Titulo deve conter até 80 Caracteres")]
        public string Title {get; set;}
        [Required(ErrorMessage ="Descricao Invalida")]
        public string Description {get; set;}
        [Required(ErrorMessage = "Id")]
        public long Id { get; set; }
    }
}