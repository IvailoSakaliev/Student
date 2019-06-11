using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.VModels.Models.Orders
{
    public class OrderVM
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public IEnumerable<SelectListItem> Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        public string FromtImage { get; set; }

        [Required]
        public List<string> Image { get; set; }


        public OrderVM()
        {
            Image = new List<string>();
        }
    }
}