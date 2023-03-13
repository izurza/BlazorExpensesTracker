using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpensesTracker.Model
{
    public class Category
    {
        /*[Range(1,10)] validador para rango de valores int*/
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, introduzca el nombre")]
        /*[EmailAddress] validador para emails validos sin usar regex*/
        /*[StringLength(100)] validador para longitud de string*/
        /*[RegularExpression(pattern:"")]validador regex*/
        public string Name { get; set; }
 
    }
}
