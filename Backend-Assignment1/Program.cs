using Backend_Assignment1.Models.Heroes;
using Backend_Assignment1.Models.Items;
using BackendAssignment1.Enums.ItemTypes;

namespace Backend_Assignment1
{
    internal class Program
    {
        static void Main(string[] args) {
            Mage mage = new("");
            Weapon weapon = new("", 0, WeaponType.Staffs, 1);
            Armor armor = new("",0, BackendAssignment1.Enums.Slot.Legs, ArmorType.Cloth, new(2, 2, 2));
            mage.Equip(weapon);
            mage.Equip(armor);
            Console.WriteLine(mage.Damage(mage.TotalAttributes()));

        }
    }
}