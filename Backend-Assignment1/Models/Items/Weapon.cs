using BackendAssignment1.Enums;
using BackendAssignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Models.Items
{
    /// <summary>
    /// Weapon. Extends Item.
    /// </summary>
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; }
        public int WeaponDamage { get; }
        public Weapon(
            string name,
            int requiredLevel,
            WeaponType weaponType,
            int weaponDamage
            ) : base(name, requiredLevel, Slot.Weapon)
        {
            WeaponType = weaponType;

            // Set WeaponDamage 
            if (weaponDamage >= 2) {
                WeaponDamage = weaponDamage;
            } else {
                throw new ArgumentException(
                    "weaponDamage must be a number greater than or equal to 2"
                    );
            }
           
        }
    }
}
