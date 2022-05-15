using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
namespace Personal.Models
{
    public class Viewmodel
    {
        public IEnumerable<TBslider> sliderinfo  { get; set; }
        public IEnumerable<Tbaboutme> aboutme  { get; set; }
        public IEnumerable<Tbservice> service { get; set; }
        public IEnumerable<Tbmywork> work { get; set; }
        public IEnumerable<Tbcontect> contect { get; set; }
    }
}
