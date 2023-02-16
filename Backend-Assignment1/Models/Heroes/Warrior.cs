using Backend_Assignment1.Models.Attributes;
using BackendAssignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Models.Heroes
{
    public class Warrior : Hero
    {
        public override HeroAttributes LevelAttributes { get; set; } =
            new(5, 2, 1);
        public override HeroAttributes
            AttributesThatAreGainedWhenLevellingUp
        { get; } = new(3, 2, 1);
        protected override HashSet<WeaponType> ValidWeaponTypes { get; } =
            new()
            {
                WeaponType.Axes,
                WeaponType.Hammers,
                WeaponType.Swords
            };
        protected override HashSet<ArmorType> ValidArmorTypes { get; } =
            new() { ArmorType.Mail, ArmorType.Plate };

        public Warrior(string name) : base(name) { }

        protected override int DamagingAttribute(HeroAttributes totalAttributes)
        {
            return totalAttributes.Strength;
        }
    }
}
