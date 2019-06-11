using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class Contact
        : BaseModel
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
    }
}
