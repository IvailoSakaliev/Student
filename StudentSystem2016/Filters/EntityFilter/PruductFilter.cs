using DataAcsess.Models;
using StudentSystem2016.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem2016.Filters.EntityFilter
{
    public class PruductFilter
        : GenericFiler<Product>
    {
        public PruductFilter()
        {

        }

        [FilterProperty(DisplayName = "Title")]
        public string Title { get; set; }

        public override Expression<Func<Product, bool>> BildFilter()
        {

            Expression<Func<Product, bool>> filter =
                u => (string.IsNullOrEmpty(this.Title) || u.Title.Contains(this.Title.Trim()));
            return filter;
        }
    }
}