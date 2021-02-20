using System;
using System.Collections.Generic;
using System.Text;

namespace MagisterShop.Infraastructure.DTOs
{
    public class ProductDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfAddition { get; set; }
        public UserDTO User { get; set; }
        public RatingDTO Rating { get; set; }

    }
}
