using Backend_Assignment1.Enums.ItemTypes;
using Backend_Assignment1.Attributes;

namespace Backend_Assignment1.Heroes
{
    internal class Mage : Hero
    {
        protected override HeroAttributes LevelAttributes { get; set; } = 
            new(1, 1, 8);
        protected override HeroAttributes 
            AttributesThatAreGainedWhenLevellingUp { get; } = new(1, 1, 5);
        protected override HashSet<WeaponType> ValidWeaponTypes { get; } = 
            new() { WeaponType.Staffs, WeaponType.Wands };
        protected override HashSet<ArmorType> ValidArmorTypes { get; } = 
            new() { ArmorType.Cloth };

        public Mage(string name) : base(name) {}

        protected override int DamagingAttribute(HeroAttributes totalAttributes)
        {
            return totalAttributes.Intelligence;
        }

    }
}
