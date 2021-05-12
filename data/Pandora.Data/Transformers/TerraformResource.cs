using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using NUnit.Framework.Constraints;
using Pandora.Definitions.Interfaces;
using SchemaToResourceIdMapping = Pandora.Data.Models.SchemaToResourceIdMapping;
using TerraformResourceDefinition = Pandora.Data.Models.TerraformResourceDefinition;

namespace Pandora.Data.Transformers
{
    public static class TerraformResource
    {
        public static TerraformResourceDefinition Map(Definitions.Interfaces.TerraformResourceDefinition input)
        {
            // TODO: tests
            
            // validate the input data is good
            if (input.ResourceType == Definitions.Interfaces.TerraformResourceType.Unknown)
            {
                throw new NotSupportedException($"resource {input.ResourceName} is of an unsupported type");
            }
            if (input.Functions.Any(f => input.Functions.Count(fn => f.GetType().FullName == fn.GetType().FullName) > 1))
            {
                throw new NotSupportedException($"resource {input.ResourceName} has duplicate functions");
            }
            if (input.Functions.Any(f => input.Functions.Count(fn => f.Type == fn.Type) > 1))
            {
                throw new NotSupportedException($"resource {input.ResourceName} has duplicate function types");
            }
            if (input.Tests.Any(t => input.Tests.Count(tst => tst.Name == t.Name) > 1))
            {
                throw new NotSupportedException($"resource {input.ResourceName} has duplicate name for tests");
            }
            
            var apiDefinition = APIDefinition.Map(input.Api);
            var functions = input.Functions.Select(TerraformFunction.Map).ToList();
            var resourceId = ResourceID.Map(input.ResourceId);
            var name = input.GetType().Name;
            var schemaToResourceIdMapping = MapSchemaToResourceIdMapping(input.SchemaToResourceIdMappings, input.ResourceId);
            var schema = SchemaDefinition.Map(input.Schema);
            var tests = input.Tests.Select(TerraformSchemaTest.Map).ToList();
            return new Models.TerraformResourceDefinition
            {
                ApiDefinition = apiDefinition,
                IsDataSource = input.ResourceType == Definitions.Interfaces.TerraformResourceType.DataSource,
                Functions = functions,
                Generate = input.Generate,
                Name = name,
                ResourceId = resourceId,
                SchemaToResourceIdMapping = schemaToResourceIdMapping,
                ResourceLabel = input.ResourceName,
                Schema = schema,
                Tests = tests,
            };
        }

        private static SchemaToResourceIdMapping MapSchemaToResourceIdMapping(List<Definitions.Interfaces.SchemaToResourceIdMapping> mappings, Definitions.Interfaces.ResourceID resourceId)
        {
            var resourceIdType = resourceId.GetType().Name;
            var segmentMappings = mappings.Select(m =>
            {
                if (m.SpecialField != null)
                {
                    switch (m.SpecialField.Value)
                    {
                        case SpecialFieldType.SubscriptionId:
                            return "special:subscriptionId";
                            
                        default:
                            throw new NotSupportedException($"Special Field Type {m.SpecialField.Value} is not fully configured!");
                    }
                }

                return m.SchemaField;
            }).ToList();
            return new SchemaToResourceIdMapping
            {
                ResourceIdType = resourceIdType,
                SegmentMapping = segmentMappings,
            };
        }
    }
}