using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Requests.Categories
{
    public class DeleteCategoryRequest : Request
    {
        [Required(ErrorMessage = "Id")]
        public long Id { get; set; }
    }
}