using Backend_Assignment1.HeroAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Assignment1.Heroes
{
    internal class Warrior : Hero
    {
        protected override HeroAttributes LevelAttributes { get; set; } = new(5, 2, 1);
        protected override HeroAttributes AttributesThatAreGainedWhenLevellingUp { get; } = new(3, 2, 1);

        public Warrior(string name) : base(name)
        {
        }

    }
}
