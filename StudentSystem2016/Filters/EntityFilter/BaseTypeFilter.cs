using DataAcsess.Models;
using StudentSystem2016.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem2016.Filters.EntityFilter
{
    public class BaseTypeFilter
        : GenericFiler<BaseType>
    {
        [FilterProperty(DisplayName = "Name")]
        public string Name { get; set; }

        public override Expression<Func<BaseType, bool>> BildFilter()
        {
            Expression<Func<BaseType, bool>> filter =
                u => (string.IsNullOrEmpty(this.Name) || u.Name.Contains(this.Name.Trim()));
            return filter;
        }
    }
}