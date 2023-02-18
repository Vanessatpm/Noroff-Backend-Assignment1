namespace Backend_Assignment1.Models.Attributes
{
    /// <summary>
    /// Represents hero attributes.
    /// </summary>
    public class HeroAttributes
    {
        public int Strength { get; }
        public int Dexterity { get; }
        public int Intelligence { get; }
        public HeroAttributes(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        static public HeroAttributes Add(
            HeroAttributes attributes1,
            HeroAttributes attributes2
            )
        {
            int strengthSum = attributes1.Strength + attributes2.Strength;
            int dexteritySum = attributes1.Dexterity + attributes2.Dexterity;
            int intelligenceSum =
                attributes1.Intelligence + attributes2.Intelligence;

            return new HeroAttributes(strengthSum, dexteritySum, intelligenceSum);
        }
    }
}
