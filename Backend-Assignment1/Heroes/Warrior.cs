using Backend_Assignment1.Enums.ItemTypes;
using Backend_Assignment1.Attributes;

namespace Backend_Assignment1.Heroes
{
    internal class Warrior : Hero
    {
        protected override HeroAttributes LevelAttributes { get; set; } = 
            new(5, 2, 1);
        protected override HeroAttributes 
            AttributesThatAreGainedWhenLevellingUp { get; } = new(3, 2, 1);
        protected override HashSet<WeaponType> ValidWeaponTypes { get; } = 
            new() 
            { 
                WeaponType.Axes, 
                WeaponType.Hammers, 
                WeaponType.Swords 
            };
        protected override HashSet<ArmorType> ValidArmorTypes { get; } = 
            new() { ArmorType.Mail, ArmorType.Plate};

        public Warrior(string name) : base(name) {}

        protected override int DamagingAttribute(HeroAttributes totalAttributes)
        {
            return totalAttributes.Strength;
        }
    }
}
