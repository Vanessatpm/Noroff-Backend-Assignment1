using Backend_Assignment1.Models.Attributes;
using BackendAssignment1.Enums;
using BackendAssignment1.Enums.ItemTypes;

namespace Backend_Assignment1.Models.Items

{
    public class Armor : Item
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

            // Set ArmorAttributes
            if (
                armorAttributes.Strength >= 0
                && armorAttributes.Dexterity >= 0
                && armorAttributes.Intelligence >= 0
                ) 
            { 
                ArmorAttributes = armorAttributes;
            } else 
            {
                throw new ArgumentException(
                    "armorAttributes must have attributes greater than or equal to 0"
                    );
            }

        }
    }
}
