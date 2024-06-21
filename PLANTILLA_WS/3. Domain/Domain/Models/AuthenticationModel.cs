using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AuthenticationModel
    {
        public class LoginModel
        {
            [Required]
            public string EMAIL { get; set; }
            [Required]
            public string PASSWORD { get; set; }
        }
        public class RegisterModel
        {
            public int ID_USER { get; set; }
            public string NAME_USER { get; set; }
            public string LASTNAME_USER { get; set; }
            public string EMAIL { get; set; }
            public string PASSWORD { get; set; }
            public DateTime BORN_DATE { get; set; }
            public string ROLE { get; set; }
            public string SEX { get; set; }
            public string DNI_USER { get; set; }
        }
    }
}
