using System;

namespace SchwabenCode.MicroCQRS.Core
{
    /// <summary>
    /// Exception that represents that the system founds multiple handlers for one query which is invalid
    /// </summary>
    public class MultipleQueryHandlersFoundException : Exception
    {
        /// <summary>
        /// Unknown query type
        /// </summary>
        public Type QueryType { get; }

        /// <summary>
        /// Creates an instance of <see cref="MultipleQueryHandlersFoundException"/>
        /// </summary>
        public MultipleQueryHandlersFoundException(Type queryType) : base($@"Multiple query handlers of ""{queryType.FullName}"" found.")
        {
            if (queryType == null) throw new ArgumentNullException(nameof(queryType));

            QueryType = queryType;
        }
    }
}