using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;
using Pandora.Definitions.Mappings;

namespace Pandora.Data.Transformers;

public static class TerraformMappingDefinition
{
    public static Models.TerraformMappingDefinition Map(Definitions.Interfaces.TerraformMappingDefinition input)
    {
        var resourceIds = new List<Models.TerraformResourceIDMappingDefinition>();

        foreach (var item in input.Mappings)
        {
            if (item is ResourceIdMapping resourceIdMapping)
            {
                resourceIds.Add(new TerraformResourceIDMappingDefinition
                {
                    SegmentName = resourceIdMapping.SegmentName,
                    SchemaFieldName = resourceIdMapping.SchemaFieldName
                });
                continue;
            }

            if (item is FromMapping.PlaceholderMapping)
            {
                // TODO: replace this
                continue;
            }

            throw new NotSupportedException($"unsupported mapping type {item.GetType().Name}");
        }

        return new Models.TerraformMappingDefinition
        {
            ResourceIds = resourceIds.ToList(),
        };
    }
}