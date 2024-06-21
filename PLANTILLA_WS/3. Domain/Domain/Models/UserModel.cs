using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserModel
    {
        public int ID_USER { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }
        public string NAME_USER { get; set; }
        public string LASTNAME_USER { get; set; }
        public string EMAIL { get; set; }
        public DateTime BORN_DATE { get; set; }
        public string ROLE { get; set; }
        public string SEX { get; set; }
        public string DNI_USER { get; set; }
        public Byte[] PHOTO_USER { get; set; }
    }
}
