using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem2016.Filters
{
    public abstract class GenericFiler<Tentity> 
        :  IGenericFilter where Tentity: BaseModel
    {
        public string Prefix { get; set; }
        public abstract Expression<Func<Tentity, bool>> BildFilter();
    }
        
    
}