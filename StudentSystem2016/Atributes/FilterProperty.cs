using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem2016.Atributes
{
    public class FilterPropertyAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public string DropDownTargetPropery { get; set; }

    }
}