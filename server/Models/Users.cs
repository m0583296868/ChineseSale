using System.ComponentModel;

namespace MSMA.Models
{
    public class Users
    {
        public string Name{ get; set; }
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
       public IEnumerable<Cards> Cards { get; set; }

        public string UserName { get; set; }
       
        public string Role { get; set; } 

        public string Password { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
