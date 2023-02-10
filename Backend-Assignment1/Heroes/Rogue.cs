using Backend_Assignment1.HeroAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Assignment1.Heroes
{
    internal class Rogue : Hero
    {
        protected override HeroAttributes LevelAttributes { get; set; } = new(2, 6, 1);
        protected override HeroAttributes AttributesThatAreGainedWhenLevellingUp { get; } = new(1, 4, 1);

        public Rogue(string name) : base(name)
        {
        }


    }
}
