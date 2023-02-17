using Backend_Assignment1.Models.Attributes;
using Backend_Assignment1.Models.Items;
using BackendAssignment1.Enums;
using BackendAssignment1.Enums.ItemTypes;

namespace BackendAssignment1Tests.ItemTests
{
    /// <summary>
    /// Test Armor class. 
    /// Use Item (which is the parent class) when possible.
    /// </summary>
    public class ArmorTests
    {
        // random valid values for parameters to constructor.
        // Needed to call constructor.
        // Their values are not important, as long as they are valid.
        private readonly string _nameArg = "";
        private readonly int _requiredLevelArg = 1;
        private readonly Slot _slotArg = Slot.Body;
        private readonly ArmorType _armorTypeArg = ArmorType.Cloth;
        private readonly HeroAttributes _armorAttributesArg = new(1, 1, 1);

        #region Creation & Properties

        #region Name

        [Theory]
        [InlineData("")]
        [InlineData("name")]
        public void Constructor_WithValidName_ShouldSetNameCorrectly(
            string name
            )
        {
            // Arrange
            string expected = name;
            // Act
            // Instantiation with name. (The rest of the args are chosen randomly.)
            Item item = new Armor(
                name,
                _requiredLevelArg,
                _slotArg,
                _armorTypeArg,
                _armorAttributesArg
                );
            string actual = item.Name;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region RequiredLevel

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Constructor_WithValidRequiredLevel_ShouldSetRequiredLevelCorrectly(
            int requiredLevel
            )
        {
            // Arrange
            int expected = requiredLevel;
            // Act
            // Instantiation with requiredLevel. (The rest of the args are chosen randomly.)
            Item item = new Armor(
                _nameArg, 
                requiredLevel,
                _slotArg,
                _armorTypeArg,
                _armorAttributesArg);
            int actual = item.RequiredLevel;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Slot

        [Theory]
        [InlineData(Slot.Body)]
        [InlineData(Slot.Legs)]
        public void Constructor_WithValidSlot_ShouldSetSlotCorrectly(Slot slot)
        {
            // Arrange
            Slot expected = slot;
            // Act
            // Instantiation with slot. (The rest of the args are chosen randomly.)
            Item item = new Armor(
                _nameArg,
                _requiredLevelArg,
                slot,
                _armorTypeArg,
                _armorAttributesArg
                );
            Slot actual = item.Slot;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region ArmorType
        [Theory]
        [InlineData(ArmorType.Cloth)]
        [InlineData(ArmorType.Plate)]
        public void Constructor_WithValidArmorType_ShouldSetArmorTypeCorrectly(
            ArmorType armorType
            )
        {
            // Arrange
            ArmorType expected = armorType;
            // Act
            // Instantiation with requiredLevel. (The rest of the args are chosen randomly.)
            Armor armor = new(
                _nameArg,
                _requiredLevelArg,
                _slotArg,
                armorType,
                _armorAttributesArg);
            ArmorType actual = armor.ArmorType;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region ArmorAttributes

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 3, 1)]
        public void Constructor_WithNonnegativeArmorAttributes_ShouldSetArmorAttributesCorrectly(
            int armorStrength,
            int armorDexterity,
            int armorIntelligence
            )
        {
            // Arrange
            HeroAttributes armorAttributes 
                = new(armorStrength, armorDexterity, armorIntelligence);
            HeroAttributes expected = armorAttributes;
            // Act
            // Instantiation with armorAttributes.
            // (The rest of the args are chosen randomly.)
            Armor armor = new(
                _nameArg,
                _requiredLevelArg,
                _slotArg,
                _armorTypeArg,
                armorAttributes);
            HeroAttributes actual = armor.ArmorAttributes;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        [InlineData(-1, -1, 0)]
        public void Constructor_WithArmorAttributesContainingOneOrMoreNegativeAttributes_ShouldThrowArgumentException(
            int armorStrength,
            int armorDexterity,
            int armorIntelligence) 
        {
            // Arrange
            HeroAttributes armorAttributes
                = new(armorStrength, armorDexterity, armorIntelligence);
            // Act and assert
            Assert.Throws<ArgumentException>(() =>
            // Instantiation with weaponDamage.
            // (The rest of the args are chosen randomly.)
            new Armor(
                _nameArg,
                _requiredLevelArg,
                _slotArg,
                _armorTypeArg,
                armorAttributes));
        }
        #endregion

        #endregion
    }
}
