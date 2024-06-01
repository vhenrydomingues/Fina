using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fina.Core.Requests.Categories
{
    public class CreateCategoryRequest : Request
    {
        [Required(ErrorMessage = "Titulo Invalido")]
        [MaxLength(80,ErrorMessage ="O Titulo deve conter até 80 Caracteres")]
        public string Title {get; set;}
        [Required(ErrorMessage ="Descricao Invalida")]
        public string Description {get; set;}
    }
}