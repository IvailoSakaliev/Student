using DataAcsess.Models;
using StudentSystem2016.Filters.EntityFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Models.Orders
{
    public class OrderList
         : GenericList<Order, OrderFilter>
    {
        public OrderList()
            : base()
        {

        }
    }
}