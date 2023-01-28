using System.Runtime.Serialization;

namespace ScholarHat.Models.DataAccess
{
    [Serializable]
    internal class EmployeeNotFindException : Exception
    {
        public EmployeeNotFindException()
        {
        }

        public EmployeeNotFindException(string? message) : base(message)
        {
        }

        public EmployeeNotFindException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmployeeNotFindException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}