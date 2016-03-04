﻿using System;

namespace SchwabenCode.MicroCQRS
{
    /// <summary>
    /// Exception that represents that the system founds multiple handlers for one query which is invalid
    /// </summary>
    public sealed class MultipleQueryHandlersFoundException : Exception
    {
        /// <summary>
        /// Unknown query type
        /// </summary>
        public Type QueryType { get; }

        /// <summary>
        /// Creates an instance of <see cref="MultipleQueryHandlersFoundException"/>
        /// </summary>
        public MultipleQueryHandlersFoundException( Type queryType ) : base( $@"Multiple query handlers of ""{queryType.FullName}"" found." )
        {
            QueryType = queryType;
        }
    }
}