using Final_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Backend.ViewModels
{
    public class HomeVM
    {
        public PageIntro pageIntro { get; set; }
        public What what { get; set; }
        public IEnumerable<Card> card { get; set; }
        public IEnumerable<Web> web { get; set; }

    }
}
