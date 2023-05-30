using Pandora.Data.Models;

namespace Pandora.Api.V1.Helpers;

public static class ServiceDefinitionTypeHelpers
{
    public static ServiceDefinitionType? ParseServiceDefinitionTypeFromApiVersion(this string apiVersion)
    {
        if (apiVersion == "beta")
        {
            return ServiceDefinitionType.MicrosoftGraphBeta;
        }
        
        if (apiVersion == "stable-v1")
        {
            return ServiceDefinitionType.MicrosoftGraphStableV1;
        }

        return null;
    }
}