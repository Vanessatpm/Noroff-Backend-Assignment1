using BackendAssignment1.Enums;
using BackendAssignment1.Enums.ItemTypes;
using System.Text;
using Backend_Assignment1.Models.Items;
using Backend_Assignment1.Models.Attributes;
using Backend_Assignment1.Exceptions.InvalidItemExceptions;

namespace Backend_Assignment1.Models.Heroes
{
    /// <summary>
    /// Abstract class to represent a hero, which is a type of role 
    /// in the role-playing game.
    /// </summary>
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

        #region Methods that alter the hero's state

        /// <summary>
        /// Increases the level by one, and increases the level attributes 
        /// accordingly.
        /// </summary>
        public void LevelUp()
        {
            Level++;

            // Increase level attributes:
            LevelAttributes = HeroAttributes.Add(
                LevelAttributes,
                AttributesThatAreGainedWhenLevellingUp
                );
        }

        /// <summary>
        /// Equips this hero with the weapon that is given to this method.
        /// If the weapon is of the wrong type, or if it requires the hero to be at
        /// a higher level, an InvalidWeaponException is thrown instead.
        /// </summary>
        /// <param name="weapon"></param>
        /// <exception cref="InvalidWeaponException"></exception>
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

        /// <summary>
        /// Equips this hero with the armor that is given to this method.
        /// If the armor is of the wrong type, or if it requires the hero to be at
        /// a higher level, an InvalidWeaponException is thrown instead.
        /// </summary>
        /// <param name="armor"></param>
        /// <exception cref="InvalidArmorException"></exception>
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
        #endregion

        #region Display method

        /// <summary>
        /// Displays this hero's current state.
        /// </summary>
        /// <returns>
        /// A string containing the hero's
        /// name,
        /// class name,
        /// level,
        /// total strength,
        /// total dexterity,
        /// total intelligence,
        /// and damaging capabilities.
        /// </returns>
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
        #endregion

        #region Methods that do calculations

        /// <summary>
        /// Calculates this hero's total attributes from the hero's level attributes
        /// and the attributes of the hero's armor.
        /// </summary>
        /// <returns>This hero's total attributes</returns>
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

        /// <summary>
        /// Calculates the total damage that this hero can deal with the current 
        /// weapon and current attributes.
        /// </summary>
        /// <param name="totalAttributes">
        /// The current total attributes of this hero.
        /// </param>
        /// <returns>
        /// The total damage that this hero can deal with the current weapon
        /// and current attributes.
        /// </returns>
        public double Damage(HeroAttributes totalAttributes)
        {
            return WeaponDamage() * (1 + DamagingAttribute(totalAttributes) / 100.0);
        }

        /// <summary>
        /// Returns a measure of the damage that the hero's current weapon can 
        /// contribute to cause.
        /// </summary>
        /// <returns>
        /// A measure of the damage that this hero's current weapon can contribute to cause,
        /// if this hero has a weapon. If this hero does not have one, this method returns 1,
        /// which represents no contribution to the damage.
        /// </returns>
        private int WeaponDamage()
        {
            Weapon? weapon = (Weapon?)_equipment[Slot.Weapon];
            return weapon?.WeaponDamage ?? 1;
        }

        /// <summary>
        /// Returns one of this hero's total attributes, which is
        /// an integer number that contributes to the total damage
        /// that this hero can deal.
        /// </summary>
        /// <param name="totalAttributes">
        /// The current total attributes of this hero.
        /// </param>
        /// <returns>One of this hero's total attributes</returns>
        protected abstract int DamagingAttribute(HeroAttributes totalAttributes);

        #endregion
    }
}