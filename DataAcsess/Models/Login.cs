using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class Login : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isRegisted { get; set; }
        public int Role { get; set; }
    }
}
