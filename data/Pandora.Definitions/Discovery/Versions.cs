using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Discovery
{
    public class Versions
    {
        public static List<ApiVersionDefinition> WithinServiceDefinition(ServiceDefinition input)
        {
            // the namespace is reliable if this is a class in it's own right (e.g. Foo.Bar.MyClass) however when
            // it's a nested class that becomes `Foo.Bar+MyClass` or `Foo.Bar+MyClass+MyThing`) so we need to compute
            // the real containing namespace
            var containingNamespace = input.GetType().Namespace;
            if (input.GetType().FullName.Contains("+"))
            {
                containingNamespace = input.GetType().FullName;
                containingNamespace = containingNamespace!.Replace(input.GetType().Name, "");
                containingNamespace = containingNamespace.TrimEnd('+');
            }
            
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.DefinedTypes);
            var versionDefinitionTypes = types.Where(t => t.IsAssignableTo(typeof(ApiVersionDefinition)) && t.FullName.StartsWith(containingNamespace) ).ToList();
            var versionDefinitions = versionDefinitionTypes.Select(Activator.CreateInstance).Select(t => t as ApiVersionDefinition).ToList();
            return versionDefinitions;
        }
    }
}