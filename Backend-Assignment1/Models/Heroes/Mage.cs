using Backend_Assignment1.Models.Attributes;
using BackendAssignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Models.Heroes
{
    /// <summary>
    /// Represents a mage. Extends Hero.
    /// </summary>
    public class Mage : Hero
    {
        public override HeroAttributes LevelAttributes { get; set; } =
            new(1, 1, 8);
        public override HeroAttributes
            AttributesThatAreGainedWhenLevellingUp { get; } = new(1, 1, 5);
        protected override HashSet<WeaponType> ValidWeaponTypes { get; } =
            new() { WeaponType.Staffs, WeaponType.Wands };
        protected override HashSet<ArmorType> ValidArmorTypes { get; } =
            new() { ArmorType.Cloth };

        public Mage(string name) : base(name) { }

        /// <summary>
        /// Returns this mage's total intelligence, which is
        /// an integer number that contributes to the total damage
        /// that this mage can deal.
        /// </summary>
        /// <param name="totalAttributes">
        /// The current total attributes of this mage.
        /// </param>
        /// <returns>This mage's total intelligence.</returns>
        protected override int DamagingAttribute(HeroAttributes totalAttributes)
        {
            return totalAttributes.Intelligence;
        }

    }
}
