using Backend_Assignment1.Models.Attributes;
using BackendAssignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Models.Heroes
{
    /// <summary>
    /// A ranger. Extends Hero.
    /// </summary>
    public class Ranger : Hero
    {
        public override HeroAttributes LevelAttributes { get; set; } =
            new(1, 7, 1);
        public override HeroAttributes
            AttributesThatAreGainedWhenLevellingUp
        { get; } = new(1, 5, 1);
        protected override HashSet<WeaponType> ValidWeaponTypes { get; } =
            new() { WeaponType.Bows };
        protected override HashSet<ArmorType> ValidArmorTypes { get; } =
            new() { ArmorType.Leather, ArmorType.Mail };

        public Ranger(string name) : base(name) { }

        protected override int DamagingAttribute(HeroAttributes totalAttributes)
        {
            return totalAttributes.Dexterity;
        }


    }
}
