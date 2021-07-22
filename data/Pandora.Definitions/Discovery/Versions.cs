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
            var containingNamespace = Helpers.ContainingNamespaceForType(input.GetType());
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.DefinedTypes);
            var versionDefinitionTypes = types.Where(t => t.IsAssignableTo(typeof(ApiVersionDefinition)) && t.FullName.StartsWith(containingNamespace)).ToList();
            var versionDefinitions = versionDefinitionTypes.Select(Activator.CreateInstance).Select(t => t as ApiVersionDefinition).ToList();
            return versionDefinitions;
        }
    }
}