using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Discovery;

public static class Versions
{
    public static List<ApiVersionDefinition> WithinServiceDefinition(ServiceDefinition input)
    {
        var containingNamespace = Helpers.ContainingNamespaceForType(input.GetType());
        var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.DefinedTypes);
        // The FullName for a Type is `Namespace.TypeName` - so whilst searching for a prefix of `Namespace` works in most cases
        // some services use the same prefix as other services - for example RecoveryServices, RecoveryServicesBackup & RecoveryServicesSiteRecovery
        // as such we check for a prefix of `Namespace.` which'll exact match this namespace, rather than all 3 in this instance
        var namespaceToSearchFor = containingNamespace + ".";
        if (input.GetType().FullName.Contains("+"))
        {
            // however when testing we use internal nested classes, which are listed differently - so we need to be able to dynamically look these up
            // we could move these for testing purposes, but it's beneficial to keep these together tbh
            namespaceToSearchFor = containingNamespace;
        }

        var versionDefinitionTypes = types.Where(t => t.IsAssignableTo(typeof(ApiVersionDefinition)) && t.FullName.StartsWith(namespaceToSearchFor)).ToList();
        var versionDefinitions = versionDefinitionTypes.Select(Activator.CreateInstance).Select(t => t as ApiVersionDefinition).ToList();
        return versionDefinitions;
    }
}