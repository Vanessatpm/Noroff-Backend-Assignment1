using Backend_Assignment1.Enums;
using Backend_Assignment1.Enums.ItemTypes;
using Backend_Assignment1.Attributes;
using Backend_Assignment1.Items;
using Backend_Assignment1.Exceptions;
using System.Text;

namespace Backend_Assignment1.Heroes
{
    internal abstract class Hero
    {
        private readonly string _name;
        private int _level = 1;
        private readonly Dictionary<Slot, Item?> equipment = new() {
            { Slot.Weapon, null },
            { Slot.Head, null },
            { Slot.Body, null },
            { Slot.Legs, null }
        };
        protected abstract HeroAttributes LevelAttributes { get; set; }
        protected abstract HeroAttributes 
            AttributesThatAreGainedWhenLevellingUp { get; }
        protected abstract HashSet<WeaponType> ValidWeaponTypes { get; }
        protected abstract HashSet<ArmorType> ValidArmorTypes { get; }


        protected Hero(string name)
        {
            _name = name;
        }

        public void LevelUp()
        {
            _level++;

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
                && _level >= weapon.RequiredLevel;

            if (weaponIsValid)
            {
                equipment[weapon.Slot] = weapon;
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
                    $"{_name} is on level {_level} but " +
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
                && _level >= armor.RequiredLevel;

            if (armorIsValid)
            {
                equipment[armor.Slot] = armor;
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
                    $"{_name} is on level {_level} but " +
                    $"needs to be on level {armor.RequiredLevel} " +
                    $"or higher to acquire this armor.");
            }
        }

        protected HeroAttributes TotalAttributes()
        {
            // Calculate the sum of all the armor attributes.
            HeroAttributes totalArmorAttributes = new(0, 0, 0);
            foreach (KeyValuePair<Slot, Item?> slotItemPair in equipment)
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

        private double Damage(HeroAttributes totalAttributes) {
            return WeaponDamage() * (1 + DamagingAttribute(totalAttributes) / 100.0);
        }
        private int WeaponDamage()
        {
            Weapon? weapon = (Weapon?)equipment[Slot.Weapon];
            return weapon?.WeaponDamage ?? 1;
        }
        protected abstract int DamagingAttribute(HeroAttributes totalAttributes);

        public string Display()
        {
            HeroAttributes totalattributes = TotalAttributes();

            StringBuilder displayString = new($"THE STATE OF {_name.ToUpper()}:\n");
            displayString.AppendLine($"Name: {_name}");
            displayString.AppendLine($"Class: {GetType().Name}");
            displayString.AppendLine($"Level: {_level}");
            displayString.AppendLine($"Total strength: {totalattributes.Strength}");
            displayString.AppendLine($"Total dexterity: {totalattributes.Dexterity}");
            displayString.AppendLine($"Total intelligence: {totalattributes.Intelligence}");
            displayString.AppendLine($"Damage: {Damage(totalattributes)}");

            return displayString.ToString();
        }

    }
}