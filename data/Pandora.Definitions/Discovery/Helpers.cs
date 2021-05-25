using System;

namespace Pandora.Definitions.Discovery
{
    internal class Helpers
    {
        internal static string ContainingNamespaceForType(Type input)
        {
            // the namespace is reliable if this is a class in it's own right (e.g. Foo.Bar.MyClass) however when
            // it's a nested class that becomes `Foo.Bar+MyClass` or `Foo.Bar+MyClass+MyThing`) so we need to compute
            // the real containing namespace
            var containingNamespace = input.Namespace;
            if (input.FullName.Contains("+"))
            {
                containingNamespace = input.FullName;
                containingNamespace = containingNamespace!.Replace(input.GetType().Name, "");
                containingNamespace = containingNamespace.TrimEnd('+');
            }

            return containingNamespace;
        } 
    }
}