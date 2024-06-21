using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UserViewModel
    {
        public int idUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string nameUser { get; set; }
        public string lastnameUser { get; set; }
        public string email { get; set; }
        public DateTime bornDate { get; set; }
        public string role { get; set; }
        public string sex { get; set; }
        public string dniUser { get; set; }
        public Byte[] photoUser { get; set; }
    }
}
