using System;
using System.Linq;
using ServiceDefinition = Pandora.Data.Models.ServiceDefinition;

namespace Pandora.Data.Transformers
{
    public static class Service
    {
        public static ServiceDefinition Map(Definitions.Interfaces.ServiceDefinition input)
        {
            try
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

                return new ServiceDefinition
                {
                    Generate = input.Generate,
                    Name = input.Name,
                    ResourceManager = input.ResourceProvider != null,
                    ResourceProvider = input.ResourceProvider,
                    Versions = orderedVersions,
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping Service {input.GetType().FullName}", ex);
            }
        }
    }
}