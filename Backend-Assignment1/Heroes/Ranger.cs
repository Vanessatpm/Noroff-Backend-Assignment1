using Backend_Assignment1.Enums.ItemTypes;
using Backend_Assignment1.Attributes;

namespace Backend_Assignment1.Heroes
{
    internal class Ranger : Hero
    {
        protected override HeroAttributes LevelAttributes { get; set; } = 
            new(1, 7, 1);
        protected override HeroAttributes 
            AttributesThatAreGainedWhenLevellingUp { get; } = new(1, 5, 1);
        protected override HashSet<WeaponType> ValidWeaponTypes { get; } = 
            new() { WeaponType.Bows };
        protected override HashSet<ArmorType> ValidArmorTypes { get; } = 
            new() { ArmorType.Leather, ArmorType.Mail };

        public Ranger(string name) : base(name) {}

        protected override int DamagingAttribute(HeroAttributes totalAttributes)
        {
            return totalAttributes.Dexterity;
        }


    }
}
