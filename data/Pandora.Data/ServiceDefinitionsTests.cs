using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pandora.Data.Repositories;
using Pandora.Definitions.DataPlane;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.ResourceManager;

namespace Pandora.Data
{
    public class ServiceDefinitionsTests
    {
        [TestCase]
        public void ValidateDataPlaneServiceDefinitions()
        {
            ValidateAssemblyContainingServiceDefinitions(new DataPlaneServices());
        }
        
        [TestCase]
        public void ValidateResourceManagerServiceDefinitions()
        {
            ValidateAssemblyContainingServiceDefinitions(new ResourceManagerServices());
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
                    new ServiceReferencesRepository(wrapper);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Service Definition {serviceDefinition.Name} should validate but failed due to: {ex}");
                }
            }
        }
    }
}