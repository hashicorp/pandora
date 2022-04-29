using System;
using System.ComponentModel;
using System.Linq;
using Pandora.Data.Models;
using Pandora.Definitions.Interfaces;

namespace Pandora.Data.Transformers;

public static class Version
{
    public static VersionDefinition Map(ApiVersionDefinition input)
    {
        try
        {
            var apis = input.Resources.ToList();
            if (apis.Count == 0)
            {
                throw new NotSupportedException($"Version {input.ApiVersion} has no operations");
            }

            // protect against coding errors
            var duplicateOperations = apis.Any(a => apis.Count(api => api.GetType().FullName == a.GetType().FullName) > 1);
            if (duplicateOperations)
            {
                throw new NotSupportedException($"Version {input.ApiVersion} has duplicate operations");
            }

            var resourceDefinitions = input.Resources.Select(ResourceDefinition.Map);
            return new VersionDefinition
            {
                Resources = resourceDefinitions,
                Generate = input.Generate,
                Preview = input.Preview,
                Source = MapSource(input.Source),
                Version = input.ApiVersion,
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Mapping API Version {input.GetType().FullName}", ex);
        }
    }

    private static ApiDefinitionsSource MapSource(Source input)
    {
        switch (input)
        {
            case Source.HandWritten:
                return ApiDefinitionsSource.HandWritten;
            
            case Source.ResourceManagerRestApiSpecs:
                return ApiDefinitionsSource.ResourceManagerRestApiSpecs;
        }

        throw new NotSupportedException($"unsupported/unmapped Source ${input.ToString()}");
    }
}