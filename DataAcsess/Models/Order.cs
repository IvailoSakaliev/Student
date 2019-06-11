using DataAcsess.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.Models
{
    public class Order
       : BaseModel
    {
        public string OrderNumber { get; set; }
        public int SubjectID { get; set; }
        public int UserID { get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }
        public Status Status { get; set; }
        public double Total { get; set; }
    }
}
