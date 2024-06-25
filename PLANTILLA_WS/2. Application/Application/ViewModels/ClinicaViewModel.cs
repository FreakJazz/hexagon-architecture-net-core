using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ClinicaViewModel
    {
        public int? idClinica { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string nameClinica { get; set; }
        public string descriptionClinica { get; set; }
        public string typeClinica { get; set; }
        public string colorPrincipal { get; set; }
        public string colorSecundary { get; set; }
        public Byte[] logoClinica { get; set; }
    }
}
