using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;
using Pandora.Definitions.Interfaces;

namespace Pandora.Data.Transformers
{
    public static class APIDefinition
    {
        public static Models.ApiDefinition Map(Definitions.Interfaces.ApiDefinition input)
        {
            try
            {
                var operations = input.Operations.ToList();
                if (operations.Count == 0)
                {
                    throw new NotSupportedException($"API Version {input.GetType().Name} has no operations");
                }

                var constantDefinitions = operations.SelectMany(ConstantsForOperation).ToList();
                var modelDefinitions = operations.SelectMany(ModelsForOperation).Distinct(new ModelComparer()).ToList();
                var operationDefinitions = operations.Select(o => Operation.Map(o, input.ApiVersion, input.Name)).ToList();
                var resourceIds = operations.SelectMany(ResourceIdsForOperation).Distinct(new ResourceIDComparer()).ToList();
                
                // append any constants found in the Resource ID's to the Constants list, then finally unique the Constants
                constantDefinitions.AddRange(resourceIds.SelectMany(rid => rid.Constants).ToList());
                constantDefinitions = constantDefinitions.Distinct(new ConstantComparer()).ToList();
                
                return new Models.ApiDefinition
                {
                    ApiVersion = input.ApiVersion,
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

        private static List<ConstantDefinition> ConstantsForOperation(ApiOperation input)
        {
            var definitions = new List<ConstantDefinition>();

            if (input.RequestObject() != null)
            {
                definitions.AddRange(Constant.FromObject(input.RequestObject()!));
            }

            if (input.ResponseObject() != null)
            {
                definitions.AddRange(Constant.FromObject(input.ResponseObject()!));
            }

            // pull out any constants which are referenced against the Options block
            if (input.OptionsObject() != null)
            {
                definitions.AddRange(Constant.FromObject(input.OptionsObject()!));
            }

            return definitions.Distinct(new ConstantComparer()).ToList();
        }

        private static List<ModelDefinition> ModelsForOperation(ApiOperation input)
        {
            var definitions = new List<ModelDefinition>();

            if (input.RequestObject() != null)
            {
                definitions.AddRange(Model.Map(input.RequestObject()!));
            }

            if (input.ResponseObject() != null)
            {
                definitions.AddRange(Model.Map(input.ResponseObject()!));
            }

            return definitions.Distinct(new ModelComparer()).ToList();
        }
    }
}