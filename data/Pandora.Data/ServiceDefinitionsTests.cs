using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Data.Repositories;
using Pandora.Definitions.DataPlane;
using Pandora.Definitions.HandDefined;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta;
using Pandora.Definitions.MicrosoftGraph.Stable;
using Pandora.Definitions.ResourceManager;
using ServiceDefinition = Pandora.Data.Models.ServiceDefinition;

namespace Pandora.Data;

public class ServiceDefinitionsTests
{
    [TestCase]
    public void ValidateDataPlaneServiceDefinitions()
    {
        ValidateAssemblyContainingServiceDefinitions(new DataPlaneServices(), ServiceDefinitionType.DataPlane);
    }

    [TestCase]
    public void ValidateHandDefinedServiceDefinitions()
    {
        ValidateAssemblyContainingServiceDefinitions(new HandDefinedServices(), ServiceDefinitionType.ResourceManager);
    }

    [TestCase]
    public void ValidateMicrosoftGraphBetaServiceDefinitions()
    {
        ValidateAssemblyContainingServiceDefinitions(new MicrosoftGraphBetaServices(), ServiceDefinitionType.MicrosoftGraphBeta);
    }

    [TestCase]
    public void ValidateMicrosoftGraphStableV1ServiceDefinitions()
    {
        ValidateAssemblyContainingServiceDefinitions(new MicrosoftGraphStableV1Services(), ServiceDefinitionType.MicrosoftGraphStableV1);
    }

    [TestCase]
    public void ValidateResourceManagerServiceDefinitions()
    {
        ValidateAssemblyContainingServiceDefinitions(new ResourceManagerServices(), ServiceDefinitionType.ResourceManager);
    }

    private static void ValidateAssemblyContainingServiceDefinitions(ServicesDefinition assemblyServiceDefinition, ServiceDefinitionType definitionType)
    {
        var serviceDefinitions = Definitions.Discovery.Services.WithinServicesDefinition(assemblyServiceDefinition).ToList();
        foreach (var serviceDefinition in serviceDefinitions)
        {
            var wrapper = new Dictionary<ServiceDefinitionType, IEnumerable<Definitions.Interfaces.ServiceDefinition>>
            {
                {
                    definitionType, new List<Definitions.Interfaces.ServiceDefinition>
                    {
                        serviceDefinition,
                    }
                }
            };
            try
            {
                var repo = new ServiceReferencesRepository(wrapper);

                // try parsing out each type
                TryMapping(repo.GetAll(ServiceDefinitionType.DataPlane));
                TryMapping(repo.GetAll(ServiceDefinitionType.MicrosoftGraphBeta));
                TryMapping(repo.GetAll(ServiceDefinitionType.MicrosoftGraphStableV1));
                TryMapping(repo.GetAll(ServiceDefinitionType.ResourceManager));
            }
            catch (Exception ex)
            {
                throw new Exception($"Service Definition {serviceDefinition.Name} should validate but failed due to: {ex}");
            }
        }
    }

    private static void TryMapping(IEnumerable<ServiceDefinition> services)
    {
        // since this is lazy-loaded we need to explicitly ToList on each of these
        foreach (var service in services)
        {
            Console.WriteLine($"Validating that Service {service.Name} maps..");
            foreach (var version in service.Versions)
            {
                var apis = version.Resources.ToList();
                if (apis.Count == 0)
                {
                    throw new NotSupportedException($"Service {service.Name} / Version {version.Version} has no API's");
                }
            }
        }
    }
}