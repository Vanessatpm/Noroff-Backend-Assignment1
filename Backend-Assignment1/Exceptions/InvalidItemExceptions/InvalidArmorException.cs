namespace Backend_Assignment1.Exceptions.InvalidItemExceptions
{
    /// <summary>
    /// Exception to be thrown when an armor is not valid for being used 
    /// the way the program is trying to use it.
    /// Extends Exception.
    /// </summary>
    internal class InvalidArmorException : Exception
    {
        public InvalidArmorException(string? message) : base(message) { }
    }
}
