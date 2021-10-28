using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    [Serializable]
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Обязательное поле!")]
        [MinLength(8,ErrorMessage = "Минимальное число символов - 8")]
        [MaxLength(50, ErrorMessage ="Максимальное число символов - 50!")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Обязательное поле!")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Неправельный формат почты!")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Обязательное поле!")]
        public string Address { get; set; }
        //[Required(ErrorMessage = "Обязательное поле!")]
        public Departaments Departament { get; set; }
    }
}
