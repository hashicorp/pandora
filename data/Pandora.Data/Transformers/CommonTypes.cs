using System;
using System.Linq;
using Pandora.Data.Models;
using Pandora.Definitions.Interfaces;
using CommonTypesDefinition = Pandora.Data.Models.CommonTypesDefinition;

namespace Pandora.Data.Transformers;

public static class CommonTypes
{
    public static CommonTypesDefinition Map(Definitions.Interfaces.CommonTypesDefinition input, ServiceDefinitionType serviceDefinitionType)
    {
        try
        {
            var output = new CommonTypesDefinition
            {
                ServiceDefinitionType=serviceDefinitionType,
            };
            if (input == null)
            {
                return output;
            }

            output.Constants = input.Constants.Select(Constant.FromEnum).ToList();
            output.Models = input.Models.Select(Model.Map).Where(m => m != null).Distinct(new ModelComparer()).OrderBy(m => m.Name).ToList();

            return output;
        }
        catch (Exception ex)
        {
            throw new Exception($"Mapping CommonTypes {input.GetType().FullName}", ex);
        }
    }
}
