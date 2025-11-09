using System.ComponentModel.DataAnnotations;

namespace MyStore_Web.Models.ViewModels.Role
{
    public class RoleviewModel
    {
      
        public int Roleid { get; set; }     
        public string RoleTitle { get; set; } = null!;
        public string RoleName { get; set; } = null!;

    }
}
