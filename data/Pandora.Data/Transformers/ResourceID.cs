using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Helpers;
using Pandora.Data.Models;
using Pandora.Definitions.Interfaces;

namespace Pandora.Data.Transformers;

public static class ResourceID
{
    public static ResourceIdDefinition Map(Definitions.Interfaces.ResourceID input)
    {
        var constants = new List<ConstantDefinition>();
        var segments = new List<ResourceIdSegmentDefinition>();

        foreach (var segment in input.Segments)
        {
            var type = MapResourceIdSegmentType(segment.Type);
            var output = new ResourceIdSegmentDefinition
            {
                FixedValue = segment.FixedValue,
                Name = segment.Name,
                Type = type,
            };

            if (segment.ConstantReference != null)
            {
                var mapped = Constant.FromEnum(segment.ConstantReference!);
                constants.Add(mapped);
                output.ConstantReference = mapped.Name;
            }

            output.ExampleValue = GenerateExampleValue(output, constants);
            segments.Add(output);
        }

        return new ResourceIdDefinition
        {
            Name = input.GetType().Name,
            IdString = input.ID,
            CommonAlias = input.CommonAlias,
            Constants = constants,
            Segments = segments,
        };
    }

    private static string GenerateExampleValue(ResourceIdSegmentDefinition input, List<ConstantDefinition> constants)
    {
        switch (input.Type)
        {
            case ResourceIdSegmentType.Constant:
            {
                var constant = constants.First(c => c.Name == input.ConstantReference);
                var value = constant.Values.OrderBy(v => v.Key).First();
                return value.Value;
            }

            case ResourceIdSegmentType.ResourceGroup:
                return "example-resource-group";

            case ResourceIdSegmentType.ResourceProvider:
            case ResourceIdSegmentType.Static:
                return input.FixedValue!;

            case ResourceIdSegmentType.SubscriptionId:
                return "12345678-1234-9876-4563-123456789012";

            case ResourceIdSegmentType.Scope:
                return "/subscriptions/12345678-1234-9876-4563-123456789012/resourceGroups/some-resource-group";

            case ResourceIdSegmentType.UserSpecified:
                return input.Name.TrimSuffix("Name") + "Value";

            default:
                throw new NotSupportedException($"unimplemented segment type {input.Type.ToString()} for example value");
        }
    }

    private static ResourceIdSegmentType MapResourceIdSegmentType(ResourceIDSegmentType input)
    {
        switch (input)
        {
            case ResourceIDSegmentType.Constant:
                return ResourceIdSegmentType.Constant;

            case ResourceIDSegmentType.ResourceGroup:
                return ResourceIdSegmentType.ResourceGroup;

            case ResourceIDSegmentType.ResourceProvider:
                return ResourceIdSegmentType.ResourceProvider;

            case ResourceIDSegmentType.Scope:
                return ResourceIdSegmentType.Scope;

            case ResourceIDSegmentType.Static:
                return ResourceIdSegmentType.Static;

            case ResourceIDSegmentType.SubscriptionId:
                return ResourceIdSegmentType.SubscriptionId;

            case ResourceIDSegmentType.UserSpecified:
                return ResourceIdSegmentType.UserSpecified;

            default:
                throw new NotSupportedException($"unimplemented ResourceIDSegmentType {input.ToString()}");
        }
    }
}