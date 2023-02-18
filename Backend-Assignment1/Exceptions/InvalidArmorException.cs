
namespace BackendAssignment1.Exceptions
{
    /// <summary>
    /// Exception to be thrown when the armor is not valid for the usage
    /// that is attempted. 
    /// Extends Exception.
    /// </summary>
    internal class InvalidArmorException : Exception
    {
        public InvalidArmorException(string? message) : base(message) {}
    }
}
