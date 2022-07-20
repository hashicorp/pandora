using System;
using System.Linq;
using Pandora.Definitions.Interfaces;
using ServiceDefinition = Pandora.Data.Models.ServiceDefinition;

namespace Pandora.Data.Transformers;

public static class Service
{
    public static ServiceDefinition Map(Definitions.Interfaces.ServiceDefinition input)
    {
        try
        {
            var versions = Definitions.Discovery.Versions.WithinServiceDefinition(input);
            var orderedVersions = versions.Select(Version.Map).OrderBy(v => v.Version);
            if (!orderedVersions.Any())
            {
                throw new NotSupportedException($"Service {input.Name} has no versions defined");
            }

            // protect against coding errors
            var duplicates = orderedVersions.Where(v => orderedVersions.Count(api => v.Version == api.Version) > 1);
            if (duplicates.Any())
            {
                var duplicateVersions = string.Join(", ", duplicates.Select(v => v.Version).Distinct().Select(v => $"{v} has {duplicates.Count(d => d.Version == v)} duplicates").ToList());
                throw new NotSupportedException($"Service {input.Name} has duplicate versions defined: {duplicateVersions}");
            }

            var terraformResources = input.TerraformResources.Select(TerraformResourceDefinition.Map).ToList();
            if (terraformResources.Any(a => terraformResources.Count(b => b.ResourceLabel == a.ResourceLabel) > 1))
            {
                throw new NotSupportedException($"Resource {input} has duplicate Terraform Resources");
            }
            
            return new ServiceDefinition
            {
                Generate = input.Generate,
                Name = input.Name,
                ResourceManager = input.ResourceProvider != null,
                ResourceProvider = input.ResourceProvider,
                TerraformPackageName = input.TerraformPackageName,
                TerraformResources = terraformResources,
                Versions = orderedVersions,
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Mapping Service {input.GetType().FullName}", ex);
        }
    }
}