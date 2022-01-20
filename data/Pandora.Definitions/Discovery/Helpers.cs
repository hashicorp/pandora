using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace Pandora.Definitions.Discovery;

internal static class Helpers
{
    internal static string ContainingNamespaceForType(Type input)
    {
        // the namespace is reliable if this is a class in it's own right (e.g. Foo.Bar.MyClass) however when
        // it's a nested class that becomes `Foo.Bar+MyClass` or `Foo.Bar+MyClass+MyThing`) so we need to compute
        // the real containing namespace
        var containingNamespace = input.Namespace;
        if (input.FullName.Contains("+"))
        {
            var segments = Strings.Split(input.FullName, "+");
            containingNamespace = input.FullName;
            containingNamespace = containingNamespace!.Replace(segments.Last(), "");
            containingNamespace = containingNamespace.TrimEnd('+');
        }

        return containingNamespace;
    }
}