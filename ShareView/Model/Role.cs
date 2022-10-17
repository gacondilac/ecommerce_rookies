using System.ComponentModel.DataAnnotations;

namespace ShareView.Model
{
    public class Role
    {
        [Key]
        public int RoleID{ get; set; }
        public string RoleName{ get; set; }
    }
}
