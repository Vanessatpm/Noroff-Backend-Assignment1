using Backend_Assignment1.Enums;
using Backend_Assignment1.Attributes;
using Backend_Assignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Items

{
    internal class Armor : Item
    {
        public ArmorType ArmorType { get; } 
        public HeroAttributes ArmorAttributes { get; }
        public Armor(
            string name, 
            int requiredLevel, 
            Slot slot, 
            ArmorType armorType,
            HeroAttributes armorAttributes
            ) : base(name, requiredLevel, slot)
        {
            ArmorType = armorType;
            ArmorAttributes = armorAttributes;
        }
    }
}
