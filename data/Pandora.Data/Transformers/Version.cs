using System;
using System.Linq;
using Pandora.Data.Models;
using Pandora.Definitions;
using Pandora.Definitions.Interfaces;

namespace Pandora.Data.Transformers
{
    public static class Version
    {
        public static VersionDefinition Map(ApiVersionDefinition input)
        {
            try
            {
                var apis = input.Apis.ToList();
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

                var apiDefinitions = input.Apis.Select(APIDefinition.Map);
                return new VersionDefinition
                {
                    Apis = apiDefinitions,
                    Generate = input.Generate,
                    Preview = input.Preview,
                    Version = input.ApiVersion,
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping API Version {input.GetType().FullName}", ex);
            }
        }
    }
}