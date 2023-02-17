using Backend_Assignment1.Models.Attributes;
using Backend_Assignment1.Models.Heroes;

namespace BackendAssignment1Tests
{
    /// <summary>
    /// Test Hero and its subclasses.
    /// </summary>
    public class HeroTests
    {
        #region Creation & Properties

        #region Name

        [Theory]
        [InlineData("")]
        [InlineData("name")]
        public void MageConstructor_WithValidName_ShouldSetNamePropertyOfHeroCorrectly(
            string name
            )
        {
            // Arrange
            string expected = name;
            // Act
            Hero hero = new Mage(name);
            string actual = hero.Name;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("name")]
        public void RangerConstructor_WithValidName_ShouldSetNamePropertyOfHeroCorrectly(
            string name
            )
        {
            // Arrange
            string expected = name;
            // Act
            Hero hero = new Ranger(name);
            string actual = hero.Name;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("name")]
        public void RogueConstructor_WithValidName_ShouldSetNamePropertyOfHeroCorrectly(
            string name
            )
        {
            // Arrange
            string expected = name;
            // Act
            Hero hero = new Rogue(name);
            string actual = hero.Name;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("name")]
        public void WarriorConstructor_WithValidName_ShouldSetNamePropertyOfHero(
            string name
            )
        {
            // Arrange
            string expected = name;
            // Act
            Hero hero = new Warrior(name);
            string actual = hero.Name;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Level

        [Fact]
        public void MageInstantiation_ShouldInitializeLevelCorrectly()
        {
            // Arrange
            int expected = 1;
            // Act
            Hero hero = new Mage("");
            int actual = hero.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RangerInstantiation_ShouldInitializeLevelCorrectly()
        {
            // Arrange
            int expected = 1;
            // Act
            Hero hero = new Ranger("");
            int actual = hero.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RogueInstantiation_ShouldInitializeLevelCorrectly()
        {
            // Arrange
            int expected = 1;
            // Act
            Hero hero = new Rogue("");
            int actual = hero.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WarriorInstantiation_ShouldInitializeLevelCorrectly()
        {
            // Arrange
            int expected = 1;
            // Act
            Hero hero = new Warrior("");
            int actual = hero.Level;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region LevelAttributes

        [Fact]
        public void InstantiateMage_ShouldInitializeLevelAttributesCorrectly()
        {
            // Arrange
            HeroAttributes expected = new(1, 1, 8);
            // Act
            Hero hero = new Mage("");
            HeroAttributes actual = hero.LevelAttributes;
            // Assert
            Assert.Equivalent(expected, actual, strict: true);
        }

        [Fact]
        public void InstantiateRanger_ShouldInitializeLevelAttributesCorrectly()
        {
            // Arrange
            HeroAttributes expected = new(1, 7, 1);
            // Act
            Hero hero = new Ranger("");
            HeroAttributes actual = hero.LevelAttributes;
            // Assert
            Assert.Equivalent(expected, actual, strict: true);
        }

        [Fact]
        public void InstantiateRogue_ShouldInitializeLevelAttributesCorrectly()
        {
            // Arrange
            HeroAttributes expected = new(2, 6, 1);
            // Act
            Hero hero = new Rogue("");
            HeroAttributes actual = hero.LevelAttributes;
            // Assert
            Assert.Equivalent(expected, actual, strict: true);
        }


        [Fact]
        public void InstantiateWarrior_ShouldInitializeLevelAttributesCorrectly()
        {
            // Arrange
            HeroAttributes expected = new(5, 2, 1);
            // Act
            Hero hero = new Warrior("");
            HeroAttributes actual = hero.LevelAttributes;
            // Assert
            Assert.Equivalent(expected, actual, strict: true);
        }
        #endregion

        #region AttributesThatAreGainedWhenLevellingUp

        [Fact]
        public void InstantiateMage_ShouldInitializeAttributesThatAreGainedWhenLevellingUpCorrectly()
        {
            // Arrange
            HeroAttributes expected = new(1, 1, 5);
            // Act
            Hero hero = new Mage("");
            HeroAttributes actual = hero.AttributesThatAreGainedWhenLevellingUp;
            // Assert
            Assert.Equivalent(expected, actual, strict: true);
        }

        [Fact]
        public void InstantiateRanger_ShouldInitializeAttributesThatAreGainedWhenLevellingUpCorrectly()
        {
            // Arrange
            HeroAttributes expected = new(1, 5, 1);
            // Act
            Hero hero = new Ranger("");
            HeroAttributes actual = hero.AttributesThatAreGainedWhenLevellingUp;
            // Assert
            Assert.Equivalent(expected, actual, strict: true);
        }

        [Fact]
        public void InstantiateRogue_ShouldInitializeAttributesThatAreGainedWhenLevellingUpCorrectly()
        {
            // Arrange
            HeroAttributes expected = new(1, 4, 1);
            // Act
            Hero hero = new Rogue("");
            HeroAttributes actual = hero.AttributesThatAreGainedWhenLevellingUp;
            // Assert
            Assert.Equivalent(expected, actual, strict: true);
        }

        [Fact]
        public void InstantiateWarrior_ShouldInitializeAttributesThatAreGainedWhenLevellingUpCorrectly()
        {
            // Arrange
            HeroAttributes expected = new(3, 2, 1);
            // Act
            Hero hero = new Warrior("");
            HeroAttributes actual = hero.AttributesThatAreGainedWhenLevellingUp;
            // Assert
            Assert.Equivalent(expected, actual, strict: true);
        }

        #endregion

        #endregion

        #region LevelUp

        #region Altering of Level

        [Fact]
        public void Mage_LevelUp_ShouldIncreaseLevelByOne()
        {
            // Arrange
            Hero hero = new Mage("");
            int expected = hero.Level + 1;
            // Act
            hero.LevelUp();
            int actual = hero.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Ranger_LevelUp_ShouldIncreaseLevelByOne()
        {
            // Arrange
            Hero hero = new Ranger("");
            int expected = hero.Level + 1;
            // Act
            hero.LevelUp();
            int actual = hero.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Rogue_LevelUp_ShouldIncreaseLevelByOne()
        {
            // Arrange
            Hero hero = new Rogue("");
            int expected = hero.Level + 1;
            // Act
            hero.LevelUp();
            int actual = hero.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Warrior_LevelUp_ShouldIncreaseLevelByOne()
        {
            // Arrange
            Hero hero = new Warrior("");
            int expected = hero.Level + 1;
            // Act
            hero.LevelUp();
            int actual = hero.Level;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Altering of LevelAttributes

        [Fact]
        public void Mage_LevelUp_ShouldIncreaseLevelAttributesWithCorrectAmount()
        {
            // Arrange
            Hero hero = new Mage("");
            HeroAttributes expected = HeroAttributes.Add(
                hero.LevelAttributes, 
                hero.AttributesThatAreGainedWhenLevellingUp
                );
            // Act
            hero.LevelUp();
            HeroAttributes actual = hero.LevelAttributes;
            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Ranger_LevelUp_ShouldIncreaseLevelAttributesWithCorrectAmount()
        {
            // Arrange
            Hero hero = new Ranger("");
            HeroAttributes expected = HeroAttributes.Add(
                hero.LevelAttributes,
                hero.AttributesThatAreGainedWhenLevellingUp
                );
            // Act
            hero.LevelUp();
            HeroAttributes actual = hero.LevelAttributes;
            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Rogue_LevelUp_ShouldIncreaseLevelAttributesWithCorrectAmount()
        {
            // Arrange
            Hero hero = new Rogue("");
            HeroAttributes expected = HeroAttributes.Add(
                hero.LevelAttributes,
                hero.AttributesThatAreGainedWhenLevellingUp
                );
            // Act
            hero.LevelUp();
            HeroAttributes actual = hero.LevelAttributes;
            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void Warrior_LevelUp_ShouldIncreaseLevelAttributesWithCorrectAmount()
        {
            // Arrange
            Hero hero = new Warrior("");
            HeroAttributes expected = HeroAttributes.Add(
                hero.LevelAttributes,
                hero.AttributesThatAreGainedWhenLevellingUp
                );
            // Act
            hero.LevelUp();
            HeroAttributes actual = hero.LevelAttributes;
            // Assert
            Assert.Equivalent(expected, actual);
        }
        #endregion

        #endregion


    }
}