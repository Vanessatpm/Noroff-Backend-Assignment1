using BackendAssignment1.Enums;
using BackendAssignment1.Enums.ItemTypes;
using BackendAssignment1.Exceptions;
using System.Text;
using Backend_Assignment1.Models.Items;
using Backend_Assignment1.Models.Attributes;

namespace Backend_Assignment1.Models.Heroes
{
    public abstract class Hero
    {
        public string Name { get; }
        public int Level { get; set; } = 1;

        private readonly Dictionary<Slot, Item?> _equipment = new() {
            { Slot.Weapon, null },
            { Slot.Head, null },
            { Slot.Body, null },
            { Slot.Legs, null }
        };
        public abstract HeroAttributes LevelAttributes { get; set; }
        public abstract HeroAttributes
            AttributesThatAreGainedWhenLevellingUp
        { get; }
        protected abstract HashSet<WeaponType> ValidWeaponTypes { get; }
        protected abstract HashSet<ArmorType> ValidArmorTypes { get; }


        protected Hero(string name)
        {
            Name = name;
        }

        // Methods that alter the hero's state:
        public void LevelUp()
        {
            Level++;

            // Increase level attributes:
            LevelAttributes = HeroAttributes.Add(
                LevelAttributes,
                AttributesThatAreGainedWhenLevellingUp
                );
        }

        public void Equip(Weapon weapon)
        {
            bool weaponIsOfValidType =
                ValidWeaponTypes.Contains(weapon.WeaponType);
            bool weaponIsValid =
                weaponIsOfValidType
                && Level >= weapon.RequiredLevel;

            if (weaponIsValid)
            {
                _equipment[weapon.Slot] = weapon;
            }
            else if (!weaponIsOfValidType)
            {
                throw new InvalidWeaponException(
                    $"Weapon is of type {weapon.WeaponType}, " +
                    $"which is not obtainable for a {GetType().Name} hero."
                    );
            }
            else
            {
                throw new InvalidWeaponException(
                    $"{Name} is on level {Level} but " +
                    $"needs to be on level {weapon.RequiredLevel} " +
                    $"or higher to acquire this weapon."
                    );
            }
        }

        public void Equip(Armor armor)
        {
            bool armorIsOfValidType =
                ValidArmorTypes.Contains(armor.ArmorType);
            bool armorIsValid =
                armorIsOfValidType
                && Level >= armor.RequiredLevel;

            if (armorIsValid)
            {
                _equipment[armor.Slot] = armor;
            }
            else if (!armorIsOfValidType)
            {
                throw new InvalidArmorException(
                    $"Armor is of type {armor.ArmorType}, " +
                    $"which is not obtainable for a {GetType().Name} hero."
                    );
            }
            else
            {
                throw new InvalidArmorException(
                    $"{Name} is on level {Level} but " +
                    $"needs to be on level {armor.RequiredLevel} " +
                    $"or higher to acquire this armor.");
            }
        }

        // Display method:
        public string Display()
        {
            HeroAttributes totalattributes = TotalAttributes();

            StringBuilder displayString = new($"THE STATE OF {Name.ToUpper()}:\n");
            displayString.AppendLine($"Name: {Name}");
            displayString.AppendLine($"Class: {GetType().Name}");
            displayString.AppendLine($"Level: {Level}");
            displayString.AppendLine($"Total strength: {totalattributes.Strength}");
            displayString.AppendLine($"Total dexterity: {totalattributes.Dexterity}");
            displayString.AppendLine($"Total intelligence: {totalattributes.Intelligence}");
            displayString.AppendLine($"Damage: {Damage(totalattributes)}");

            return displayString.ToString();
        }


        // Methods that do calculations:

        public HeroAttributes TotalAttributes()
        {
            // Calculate the sum of all the armor attributes.
            HeroAttributes totalArmorAttributes = new(0, 0, 0);
            foreach (KeyValuePair<Slot, Item?> slotItemPair in _equipment)
            {
                if (slotItemPair.Value is Armor armor)
                {
                    totalArmorAttributes = HeroAttributes.Add(
                        totalArmorAttributes,
                        armor.ArmorAttributes
                        );
                }
            }

            return HeroAttributes.Add(LevelAttributes, totalArmorAttributes);
        }

        public double Damage(HeroAttributes totalAttributes)
        {
            return WeaponDamage() * (1 + DamagingAttribute(totalAttributes) / 100.0);
        }
        private int WeaponDamage()
        {
            Weapon? weapon = (Weapon?)_equipment[Slot.Weapon];
            return weapon?.WeaponDamage ?? 1;
        }
        protected abstract int DamagingAttribute(HeroAttributes totalAttributes);

    }
}