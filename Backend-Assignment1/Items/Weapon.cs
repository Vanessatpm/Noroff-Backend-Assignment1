using Backend_Assignment1.Enums;
using Backend_Assignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Items
{
    internal class Weapon : Item
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
            WeaponDamage = weaponDamage;
        }
    }
}
