using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressManager.Core
{
    public static class AssemblyExtensions
    {
        /// <summary>Determines whether a type, like IList&lt;int&gt;, implements an open generic interface, like
        /// IEnumerable&lt;&gt;. Note that this only checks against *interfaces*.</summary>
        /// <param name="candidateType">The type to check.</param>
        /// <param name="openGenericInterfaceType">The open generic type which it may impelement</param>
        /// <returns>Whether the candidate type implements the open interface.</returns>
        /// <remarks>http://stackoverflow.com/questions/503263/how-to-determine-if-a-type-implements-a-specific-generic-interface-type</remarks>
        public static bool ImplementsOpenGenericInterface( this Type candidateType, Type openGenericInterfaceType )
        {
            return
                candidateType == openGenericInterfaceType ||
                ( candidateType.IsGenericType && candidateType.GetGenericTypeDefinition() == openGenericInterfaceType ) ||
                candidateType.GetInterfaces()
                    .Any( i => i.IsGenericType && i.ImplementsOpenGenericInterface( openGenericInterfaceType ) );

        }
    }
}
