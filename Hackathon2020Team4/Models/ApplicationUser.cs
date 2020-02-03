using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;
namespace Hackathon2020Team4.Models
{
    public class ApplicationUser
    {
        public int ID { get; set; }
        [DisplayName("Прізвище")]
        public string LastName { get; set; }
        [DisplayName("Ім*я По-батькові")]
        public string FirstMidName { get; set; }
    }
}
