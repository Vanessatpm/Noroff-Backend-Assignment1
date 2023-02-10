using Backend_Assignment1.HeroAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Assignment1.Heroes
{
    internal class Mage : Hero
    {
        protected override HeroAttributes LevelAttributes { get; set; } = new(1, 1, 8);
        protected override HeroAttributes AttributesThatAreGainedWhenLevellingUp { get; } = new(1, 1, 5);

        public Mage(string name) : base(name)
        {
           
        }

    }
}
