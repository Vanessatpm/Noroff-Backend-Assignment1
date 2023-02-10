using Backend_Assignment1.HeroAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Assignment1.Heroes
{
    internal class Ranger : Hero
    {
        protected override HeroAttributes LevelAttributes { get; set; } = new(1, 7, 1);
        protected override HeroAttributes AttributesThatAreGainedWhenLevellingUp { get; } = new(1, 5, 1);

        public Ranger(string name) : base(name)
        {
        }

    }
}
