using Backend_Assignment1.Models.Attributes;
using BackendAssignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Models.Heroes
{
    public class Rogue : Hero
    {
        public override HeroAttributes LevelAttributes { get; set; } =
            new(2, 6, 1);
        public override HeroAttributes
            AttributesThatAreGainedWhenLevellingUp
        { get; } = new(1, 4, 1);
        protected override HashSet<WeaponType> ValidWeaponTypes { get; } =
            new() { WeaponType.Daggers, WeaponType.Swords };
        protected override HashSet<ArmorType> ValidArmorTypes { get; } =
            new() { ArmorType.Leather, ArmorType.Mail };

        public Rogue(string name) : base(name) { }

        protected override int DamagingAttribute(HeroAttributes totalAttributes)
        {
            return totalAttributes.Dexterity;
        }

    }
}
