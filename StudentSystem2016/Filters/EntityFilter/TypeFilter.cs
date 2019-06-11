using DataAcsess.Models;
using StudentSystem2016.Atributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem2016.Filters.EntityFilter
{
    public class TypeFilter
       : GenericFiler<TypeSubject>
    {

        [FilterProperty(DisplayName = "Type")]
        public string Type { get; set; }

        public override Expression<Func<TypeSubject, bool>> BildFilter()
        {

            Expression<Func<TypeSubject, bool>> filter =
                u => (string.IsNullOrEmpty(this.Type) || u.Name.Contains(this.Type.Trim()));
            return filter;
        }
    }
}