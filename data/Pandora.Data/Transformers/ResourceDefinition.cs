using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;
using Pandora.Definitions.Interfaces;

namespace Pandora.Data.Transformers;

public static class ResourceDefinition
{
    public static Models.ResourceDefinition Map(Definitions.Interfaces.ResourceDefinition input)
    {
        try
        {
            var operations = input.Operations.ToList();
            if (operations.Count == 0)
            {
                throw new NotSupportedException($"API Version {input.GetType().Name} has no operations");
            }

            var constantDefinitions = input.Constants.SelectMany(Constant.WithinObject).ToList();
            var modelDefinitions = input.Models.SelectMany(Model.Map).Distinct(new ModelComparer()).OrderBy(m => m.Name).ToList();
            var operationDefinitions = operations.Select(Operation.Map).ToList();
            var resourceIds = operations.SelectMany(ResourceIdsForOperation).Distinct(new ResourceIDComparer()).ToList();

            // append any constants found in the Resource ID's to the Constants list, then finally unique the Constants
            constantDefinitions.AddRange(resourceIds.SelectMany(rid => rid.Constants).ToList());
            constantDefinitions = constantDefinitions.Distinct(new ConstantComparer()).OrderBy(c => c.Name).ToList();

            return new Models.ResourceDefinition
            {
                Name = input.Name,
                Constants = constantDefinitions,
                Models = modelDefinitions,
                Operations = operationDefinitions,
                ResourceIds = resourceIds,
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Mapping API Definition {input.GetType().FullName}", ex);
        }
    }

    private static IEnumerable<ResourceIdDefinition> ResourceIdsForOperation(ApiOperation input)
    {
        var output = new List<ResourceIdDefinition>();

        if (input.ResourceId() != null)
        {
            var mapped = ResourceID.Map(input.ResourceId()!);
            output.Add(mapped);
        }

        return output;
    }
}