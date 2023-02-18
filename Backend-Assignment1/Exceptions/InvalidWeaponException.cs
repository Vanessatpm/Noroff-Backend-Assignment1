
namespace BackendAssignment1.Exceptions
{
    /// <summary>
    /// Exception to be thrown when the weapon is not valid for the usage
    /// that is attempted. 
    /// Extends Exception.
    /// </summary>
    internal class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string? message) : base(message) {}
    }
}
