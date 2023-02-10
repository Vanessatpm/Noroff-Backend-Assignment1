using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Assignment1.HeroAttribute
{
    /// <summary>
    /// Class for hero attributes.
    /// </summary>
    internal class HeroAttributes
    {
        private readonly int _strength;
        private readonly int _dexterity;
        private readonly int _intelligence;

         public HeroAttributes(int strength, int dexterity, int intelligence)
        {
            _strength = strength;
            _dexterity = dexterity;
            _intelligence = intelligence;
        }

        static public HeroAttributes Add(HeroAttributes attributes1, HeroAttributes attributes2)
        {
            int strengthSum = attributes1._strength + attributes2._strength;
            int dexteritySum = attributes1._dexterity + attributes2._dexterity;
            int intelligenceSum = attributes1._intelligence + attributes2._intelligence;

            return new HeroAttributes(strengthSum, dexteritySum, intelligenceSum);
        }
    }
}
