using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Discovery
{
    public class Services
    {
        public static List<ServiceDefinition> WithinServicesDefinition(ServicesDefinition input)
        {
            var containingNamespace = Helpers.ContainingNamespaceForType(input.GetType());
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.DefinedTypes);
            var servicesTypes = types.Where(t => t.IsAssignableTo(typeof(ServiceDefinition)) && t.FullName.StartsWith(containingNamespace)).ToList();
            var services = servicesTypes.Select(Activator.CreateInstance).Select(t => t as ServiceDefinition).ToList();
            return services;
        }
    }
}