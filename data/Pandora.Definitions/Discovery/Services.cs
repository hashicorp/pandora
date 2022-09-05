using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Discovery;

public static class Services
{
    public static List<ServiceDefinition> WithinServicesDefinition(ServicesDefinition input)
    {
        var containingNamespace = Helpers.ContainingNamespaceForType(input.GetType());
        var types = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName == input.GetType().Assembly.FullName).SelectMany(a => a.DefinedTypes);
        var servicesTypes = types.Where(t => t.FullName.StartsWith(containingNamespace) && t.IsAssignableTo(typeof(ServiceDefinition))).ToList();
        var services = servicesTypes.Select(Activator.CreateInstance).Select(t => t as ServiceDefinition).ToList();
        return services;
    }
}