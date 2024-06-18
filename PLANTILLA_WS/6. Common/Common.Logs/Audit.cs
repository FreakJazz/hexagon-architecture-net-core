using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Common.Logs
{
    public class Audit
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string Id { get; set; } = Guid.NewGuid().ToString("N"); //32 caracteres
        [Required(ErrorMessage = "")]
        public int Usuario { get; set; } = 0;
        public int Proceso { get; set; } = 0;
        public string Ip { get; set; } = "";
        public string Navegador { get; set; } = "";
        public string TipoRequest { get; set; } = "";
        public string DescripcionRequest { get; set; } = "";
        public string Servidor { get; set; } = "";
    }
}
