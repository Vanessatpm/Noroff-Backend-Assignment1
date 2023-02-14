using Backend_Assignment1.Enums;

namespace Backend_Assignment1.Items
{
    internal abstract class Item
    {
        public string Name { get; }
        public Slot Slot { get; }
        public int RequiredLevel { get; }

        protected Item(string name, int requiredLevel, Slot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }
    }
}
