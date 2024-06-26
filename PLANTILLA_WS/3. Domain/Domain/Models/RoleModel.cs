using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    public class RoleModel
    {
        [Column("id_role")]
        public int? ID_ROLE { get; set; }
        [Column("created_at")]
        public DateTime CREATED_AT { get; set; }
        [Column("updated_at")]
        public DateTime UPDATED_AT { get; set; }
        [Column("name_role")]
        public string NAME_ROLE { get; set; }
        [Column("desc_role")]
        public string DESC_ROLE { get; set; }
    }
}
