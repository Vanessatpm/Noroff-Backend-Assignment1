using Backend_Assignment1.Models.Items;
using BackendAssignment1.Enums.ItemTypes;
using BackendAssignment1.Enums;

namespace BackendAssignment1Tests.ItemTests.ItemTests
{
    /// <summary>
    /// Test Weapon class. 
    /// Use Item (which is the parent class) when possible.
    /// </summary>
    public class WeaponTests
    {
        // random *valid* values for parameters to constructor.
        // Needed to call constructor.
        // Their values are not important, as long as they are valid.
        private readonly string _nameArg = "";
        private readonly int _requiredLevelArg = 1;
        private readonly WeaponType _weaponTypeArg = WeaponType.Axes;
        private readonly int _weaponDamageArg = 2;

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
            Item item = new Weapon(
                name, 
                _requiredLevelArg, 
                _weaponTypeArg, 
                _weaponDamageArg
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
            Item item = new Weapon(
                _nameArg, 
                requiredLevel,
                _weaponTypeArg,
                _weaponDamageArg
                ); 
            int actual = item.RequiredLevel;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Slot

        [Fact]
        public void Constructor_ShouldSetSlotCorrectly()
        {
            // Arrange
            Slot slot = Slot.Weapon;
            Slot expected = slot;
            // Act
            // Instantiation. (The args are chosen randomly.)
            Item item = new Weapon(
                _nameArg,
                _requiredLevelArg,
                _weaponTypeArg,
                _weaponDamageArg);
            Slot actual = item.Slot;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region WeaponType
        [Theory]
        [InlineData(WeaponType.Bows)]
        [InlineData(WeaponType.Daggers)]
        public void Constructor_WithValidWeaponType_ShouldSetWeaponTypeCorrectly(
            WeaponType weaponType
            )
        {
            // Arrange
            WeaponType expected = weaponType;
            // Act
            // Instantiation with weaponType. (The rest of the args are chosen randomly.)
            Weapon weapon = new(
                _nameArg,
                _requiredLevelArg,
                weaponType,
                _weaponDamageArg);
            WeaponType actual = weapon.WeaponType;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Damage

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Constructor_WithWeaponDamageGreaterThanOrEqualTo2_ShouldSetWeaponDamageCorrectly(
            int weaponDamage
            )
        {
            // Arrange 
            int expected = weaponDamage;
            // Act
            // Instantiation with weaponDamage.
            // (The rest of the args are chosen randomly.)
            Weapon weapon = new(
                _nameArg,
                _requiredLevelArg,
                _weaponTypeArg,
                weaponDamage);
            int actual = weapon.WeaponDamage;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_WithWeaponDamageLessThan2_ShouldThrowArgumentException(
            int weaponDamage)
        {
            // Act and assert
            Assert.Throws<ArgumentException>(() =>
            // Instantiation with weaponDamage.
            // (The rest of the args are chosen randomly.)
            new Weapon(
                _nameArg,
                _requiredLevelArg,
                _weaponTypeArg,
                weaponDamage));
        }
        #endregion

        #endregion

    }
}
