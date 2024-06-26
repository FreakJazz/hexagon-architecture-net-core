using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class ClinicaModel
    {
        [Column("id_clinica")]
        public int? ID_CLINICA { get; set; }
        [Column("created_at")]
        public DateTime CREATED_AT { get; set; }
        [Column("updated_at")]
        public DateTime UPDATED_AT { get; set; }
        [Column("name_clinica")]
        public string NAME_CLINICA { get; set; }
        [Column("desc_clinica")]
        public string DESC_CLINICA { get; set; }
        [Column("type_clinica")]
        public string TYPE_CLINICA { get; set; }
        [Column("color_principal")]
        public string COLOR_PRINCIPAL { get; set; }
        [Column("color_secundary")]
        public string COLOR_SECUNDARY { get; set; }
        [Column("logo_clinica")]
        public Byte[] LOGO_CLINICA { get; set; }
    }
}
