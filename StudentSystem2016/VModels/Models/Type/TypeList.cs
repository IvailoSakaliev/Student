using DataAcsess.Models;
using StudentSystem2016.Filters.EntityFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Models.Type
{
    public class TypeList
        : GenericList<TypeSubject, TypeFilter>
    {
        public TypeList()
            : base()
        {
        }
    }
}