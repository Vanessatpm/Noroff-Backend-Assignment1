using Backend_Assignment1.Models.Attributes;
using BackendAssignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Models.Heroes
{
    /// <summary>
    /// Represents a warrior. Extends Hero.
    /// </summary>
    public class Warrior : Hero
    {
        public override HeroAttributes LevelAttributes { get; set; } =
            new(5, 2, 1);
        public override HeroAttributes
            AttributesThatAreGainedWhenLevellingUp { get; } = new(3, 2, 1);
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

        /// <summary>
        /// Returns this warrior's total strength, which is
        /// an integer number that contributes to the total damage
        /// that this warrior can deal.
        /// </summary>
        /// <param name="totalAttributes">
        /// The current total attributes of this warrior.
        /// </param>
        /// <returns>This warrior's total strength.</returns>
        protected override int DamagingAttribute(HeroAttributes totalAttributes)
        {
            return totalAttributes.Strength;
        }
    }
}
