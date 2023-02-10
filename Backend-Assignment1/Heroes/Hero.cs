using Backend_Assignment1.HeroAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Assignment1.Heroes
{
    internal abstract class Hero
    {
        private readonly string _name;
        private int _level = 1;
        protected abstract HeroAttributes LevelAttributes { get; set; }
        protected abstract HeroAttributes AttributesThatAreGainedWhenLevellingUp { get; }


        protected Hero(string name)
        {
            _name = name;
        }

        protected void LevelUp()
        {
            _level++;

            // Increase level attributes:
            LevelAttributes = HeroAttributes.Add(LevelAttributes, AttributesThatAreGainedWhenLevellingUp);
        }


    }
}
