using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.VModels.Models.Type
{
    public class TypeVM
    {
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }

        [Required]
        public IEnumerable<SelectListItem> BaseModel { get; set; }

        public int selectedItem { get; set; }
    }
}