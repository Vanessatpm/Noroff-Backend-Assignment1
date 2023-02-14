using Backend_Assignment1.Enums.ItemTypes;
using Backend_Assignment1.Attributes;

namespace Backend_Assignment1.Heroes
{
    internal class Rogue : Hero
    {
        protected override HeroAttributes LevelAttributes { get; set; } = 
            new(2, 6, 1);
        protected override HeroAttributes 
            AttributesThatAreGainedWhenLevellingUp { get; } = new(1, 4, 1);
        protected override HashSet<WeaponType> ValidWeaponTypes { get; } = 
            new() { WeaponType.Daggers, WeaponType.Swords };
        protected override HashSet<ArmorType> ValidArmorTypes { get; } = 
            new() { ArmorType.Leather, ArmorType.Mail };

        public Rogue(string name) : base(name) {}

        protected override int DamagingAttribute(HeroAttributes totalAttributes)
        {
            return totalAttributes.Dexterity;
        }

    }
}
