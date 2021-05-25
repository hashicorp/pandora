using System;
using System.Linq;
using Pandora.Definitions.Interfaces;
using ServiceDefinition = Pandora.Data.Models.ServiceDefinition;

namespace Pandora.Data.Transformers
{
    public static class Service
    {
        public static ServiceDefinition Map(Definitions.Interfaces.ServiceDefinition input)
        {
            var versions = Definitions.Discovery.Versions.WithinServiceDefinition(input);
            var orderedVersions = versions.Select(Version.Map).OrderBy(v => v.Version).ToList();
            if (orderedVersions.Count == 0)
            {
                throw new NotSupportedException($"Service {input.Name} has no versions defined");
            }
            
            // protect against coding errors
            var hasDuplicates = orderedVersions.Any(a => orderedVersions.Count(api => api.Version == a.Version) > 1);
            if (hasDuplicates)
            {
                throw new NotSupportedException($"Service {input.Name} has duplicate versions defined");
            }

            var dataSources = input.Resources.Where(r => r.ResourceType == TerraformResourceType.DataSource).ToList();
            // protect against coding errors
            hasDuplicates = dataSources.Any(d => dataSources.Count(ds => d.ResourceName == ds.ResourceName) > 1);
            if (hasDuplicates)
            {
                throw new NotSupportedException($"Service {input.Name} has duplicate data sources defined");
            }
            
            var resources = input.Resources.Where(r => r.ResourceType == TerraformResourceType.Resource).ToList();
            // protect against coding errors
            hasDuplicates = resources.Any(r => resources.Count(rs => r.ResourceName == rs.ResourceName) > 1);
            if (hasDuplicates)
            {
                throw new NotSupportedException($"Service {input.Name} has duplicate resources defined");
            }

            var mappedDataSources = dataSources.Select(TerraformResource.Map).ToList();
            var mappedResources = resources.Select(TerraformResource.Map).ToList();

            return new ServiceDefinition
            {
               DataSources = mappedDataSources,
               Generate = input.Generate,
               Name = input.Name,
               ResourceManager = input.ResourceProvider != null,
               ResourceProvider = input.ResourceProvider,
               Resources = mappedResources,
               Versions = orderedVersions,
            };
        }
    }
}