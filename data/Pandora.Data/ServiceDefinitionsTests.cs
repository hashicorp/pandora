using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pandora.Data.Repositories;
using Pandora.Definitions.DataPlane;
using Pandora.Definitions.HandDefined;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.ResourceManager;
using Pandora.Definitions.TestData;
using ServiceDefinition = Pandora.Data.Models.ServiceDefinition;

namespace Pandora.Data;

public class ServiceDefinitionsTests
{
    [TestCase]
    public void ValidateDataPlaneServiceDefinitions()
    {
        ValidateAssemblyContainingServiceDefinitions(new DataPlaneServices());
    }

    [TestCase]
    public void ValidateHandDefinedServiceDefinitions()
    {
        ValidateAssemblyContainingServiceDefinitions(new HandDefinedServices());
    }

    [TestCase]
    public void ValidateResourceManagerServiceDefinitions()
    {
        ValidateAssemblyContainingServiceDefinitions(new ResourceManagerServices());
    }

    [TestCase]
    public void ValidateTestDataServiceDefinitions()
    {
        ValidateAssemblyContainingServiceDefinitions(new TestDataServices());
    }

    private static void ValidateAssemblyContainingServiceDefinitions(ServicesDefinition assemblyServiceDefinition)
    {
        var serviceDefinitions = Definitions.Discovery.Services.WithinServicesDefinition(assemblyServiceDefinition).ToList();
        foreach (var serviceDefinition in serviceDefinitions)
        {
            var wrapper = new List<Definitions.Interfaces.ServiceDefinition>
            {
                serviceDefinition,
            };
            try
            {
                var repo = new ServiceReferencesRepository(wrapper);
                // first try mapping all of the resource manager calls
                TryMapping(repo.GetAll(true));
                // then try mapping all of the non-resource manager calls
                TryMapping(repo.GetAll(false));
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
                Console.WriteLine($"Validating that Service {service.Name} Version {version.Version} maps..");
                var apis = version.Apis.ToList();
                if (apis.Count == 0)
                {
                    throw new NotSupportedException($"Service {service.Name} / Version {version.Version} has no API's");
                }
            }
        }
    }
}