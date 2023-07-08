using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;
using Pandora.Definitions.Interfaces;
using CommonTypesDefinition = Pandora.Definitions.Interfaces.CommonTypesDefinition;

namespace Pandora.Data;

public static class SupportedCommonTypes
{
    public static Dictionary<ServiceDefinitionType, IEnumerable<CommonTypesDefinition>> Get()
    {
        var data = DefinitionTypes.Get();
        var output = new Dictionary<ServiceDefinitionType, IEnumerable<CommonTypesDefinition>>();
        foreach (var item in data)
        {
            var commonTypes = item.Value.Select(Definitions.Discovery.CommonTypesDefinition.ForServiceDefinition);
            output.Add(item.Key, commonTypes);
        }

        return output;
    }
}
