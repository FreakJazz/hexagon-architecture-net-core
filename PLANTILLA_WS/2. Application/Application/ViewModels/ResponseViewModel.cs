using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ResponseViewModel
    {
        public int statusCode { get; set; } = default!;
        public string message { get; set; } = string.Empty;
        public bool ok { get; set; } = default!;
        public object data { get; set; }
    }
}
