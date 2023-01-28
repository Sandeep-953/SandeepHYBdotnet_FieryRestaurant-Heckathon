using System.Runtime.Serialization;

namespace ScholarHat.Models.DataAccess
{
    [Serializable]
    internal class EmployeeNullebilException : Exception
    {
        public EmployeeNullebilException()
        {
        }

        public EmployeeNullebilException(string? message) : base(message)
        {
        }

        public EmployeeNullebilException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmployeeNullebilException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}