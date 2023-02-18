namespace Backend_Assignment1.Exceptions.InvalidItemExceptions
{
    /// <summary>
    /// Exception to be thrown when a weapon is not valid for being used 
    /// the way the program is trying to use it.
    /// Extends Exception.
    /// </summary>
    internal class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string? message) : base(message) { }
    }
}
