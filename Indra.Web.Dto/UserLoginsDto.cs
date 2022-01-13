using System.ComponentModel.DataAnnotations;

namespace Indra.Web.Dto
{
    public class UserLoginsDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public UserLoginsDto()
        {

        }
    }
}
