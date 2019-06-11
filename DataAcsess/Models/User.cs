using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class User
        : BaseModel
    {
        public string SecondName { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }
        public string Image { get; set; }
        public int LoginID { get; set; }
    }
}
