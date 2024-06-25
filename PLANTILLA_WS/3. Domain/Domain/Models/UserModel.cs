
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class UserModel
    {
        [Column("id_user")]
        public int? ID_USER { get; set; }

        [Column("created_at")]
        public DateTime CREATED_AT { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UPDATED_AT { get; set; } = DateTime.UtcNow;

        [Column("name_user")]
        public string NAME_USER { get; set; }

        [Column("lastname_user")]
        public string LASTNAME_USER { get; set; }

        [Column("email")]
        public string EMAIL { get; set; }

        [Column("born_date")]
        public DateOnly BORN_DATE { get; set; }

        [Column("role")]
        public string ROLE { get; set; }

        [Column("sex")]
        public string SEX { get; set; }

        [Column("dni_user")]
        public string DNI_USER { get; set; }

        [Column("photo_user")]
        public Byte[]? PHOTO_USER { get; set; }

        [Column("password")]
        public string PASSWORD { get; set; }
    }
}
