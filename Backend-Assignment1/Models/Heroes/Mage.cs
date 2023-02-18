using Backend_Assignment1.Models.Attributes;
using BackendAssignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Models.Heroes
{
    /// <summary>
    /// 
    /// </summary>
    public class Mage : Hero
    {
        public override HeroAttributes LevelAttributes { get; set; } =
            new(1, 1, 8);
        public override HeroAttributes
            AttributesThatAreGainedWhenLevellingUp
        { get; } = new(1, 1, 5);
        protected override HashSet<WeaponType> ValidWeaponTypes { get; } =
            new() { WeaponType.Staffs, WeaponType.Wands };
        protected override HashSet<ArmorType> ValidArmorTypes { get; } =
            new() { ArmorType.Cloth };

        public Mage(string name) : base(name) { }

        protected override int DamagingAttribute(HeroAttributes totalAttributes)
        {
            return totalAttributes.Intelligence;
        }

    }
}
