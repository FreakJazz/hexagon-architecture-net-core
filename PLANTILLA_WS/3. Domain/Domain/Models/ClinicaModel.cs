namespace Domain.Models
{
    public class ClinicaModel
    {
        public int ID_CLINICA { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }
        public string NAME_CLINICA { get; set; }
        public string DESC_CLINICA { get; set; }
        public string TYPE_CLINICA { get; set; }
        public string COLOR_PRINCIPAL { get; set; }
        public string COLOR_SECUNDARY { get; set; }
        public Byte[] LOGO_CLINICA { get; set; }
    }
}
