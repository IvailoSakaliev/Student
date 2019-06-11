using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Models.BaseTypes
{
    public class BaseTypeEditVm
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}