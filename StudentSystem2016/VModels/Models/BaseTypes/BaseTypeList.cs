using StudentSystem2016.Filters.EntityFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Models.BaseTypes
{
    public class BaseTypeList
       : GenericList<DataAcsess.Models.BaseType, BaseTypeFilter>
    {
        public BaseTypeList()
            : base()
        {

        }
    }
}