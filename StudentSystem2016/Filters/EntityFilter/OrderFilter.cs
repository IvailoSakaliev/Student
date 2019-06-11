using DataAcsess.Models;
using StudentSystem2016.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem2016.Filters.EntityFilter
{
    public class OrderFilter
        : GenericFiler<Order>
    {
        [FilterProperty(DisplayName = "Title")]
        public string Title { get; set; }


        public override Expression<Func<Order, bool>> BildFilter()
        {
            Expression<Func<Order, bool>> filter =
                u => (string.IsNullOrEmpty(this.Title) || u.Name.Contains(this.Title.Trim()));
            return filter;
        }
    }
}