using BackendAssignment1.Enums;
using BackendAssignment1.Attributes;
using BackendAssignment1.Enums.ItemTypes;

namespace BackendAssignment1.Items

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
