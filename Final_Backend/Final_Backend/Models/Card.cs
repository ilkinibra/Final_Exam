using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Backend.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string subTitle { get; set; }
        public string Description { get; set; }
    }
}
