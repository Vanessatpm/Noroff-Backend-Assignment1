using BackendAssignment1.Enums;
using BackendAssignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Models.Items
{
    /// <summary>
    /// Represents a weapon. Extends Item.
    /// </summary>
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; }

        /// <summary>
        /// A measure of the damage the weapon deals.
        /// </summary>
        public int WeaponDamage { get; }

        /// <summary>
        /// Initializes a new instance of the Weapon class.
        /// An ArgumentException is thrown if weaponDamage is less than 2.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="requiredLevel"></param>
        /// <param name="weaponType"></param>
        /// <param name="weaponDamage">Must be greater than or equal to 2</param>
        /// <exception cref="ArgumentException"></exception>
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
