using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManager;

[ApiController]
public partial class TerraformController : ControllerBase
{
    private readonly IServiceReferencesRepository _repo;

    public TerraformController(IServiceReferencesRepository repo)
    {
        _repo = repo;
    }

    [Route("/v1/resource-manager/services/{serviceName}/terraform")]
    public IActionResult Terraform(string serviceName)
    {
        var service = _repo.GetByName(serviceName, true);
        if (service == null)
        {
            return BadRequest("service not found");
        }

        return new JsonResult(MapResponse(service));
    }

    private static TerraformV1Response MapResponse(ServiceDefinition service)
    {
        return new TerraformV1Response
        {
            DataSources = new Dictionary<string, DataSourceResponse>(),
            Resources = service.TerraformResources.ToDictionary(k => k.ResourceLabel, MapResourceDefinition),
        };
    }

    private static ResourceResponse MapResourceDefinition(TerraformResourceDefinition input)
    {
        var schemaModels = MapTerraformSchemaModels(input.SchemaModels!);
        var tests = MapTerraformResourceTests(input.Tests);
        var response = new ResourceResponse
        {
            ApiVersion = input.ApiVersion,
            CreateMethod = MapMethodDefinition(input.CreateMethod),
            DeleteMethod = MapMethodDefinition(input.DeleteMethod),
            DisplayName = input.DisplayName,
            Documentation = new ResourceDocumentationDefinition
            {
                // TODO: pipe this through
                Category = "Example Category",
                Description = "Some Description for this Resource",
                ExampleUsageHcl = @"
resource 'example_resource' 'example' {
    example_field = '...'
}
".Replace("'", "\""),
                // TODO: does the top level object need a List<Categories> for the ServiceDefinition?
            },
            Resource = input.Resource,
            GenerateModel = input.GenerateModel,
            GenerateIdValidation = input.GenerateIDValidationFunction,
            GenerateSchema = input.GenerateSchema,
            Mappings = MapMappingDefinitions(input.Mappings),
            ReadMethod = MapMethodDefinition(input.ReadMethod),
            ResourceName = input.ResourceName,
            ResourceIdName = input.ResourceIdName,
            SchemaModelName = input.SchemaModelName,
            SchemaModels = schemaModels,
            Tests = tests,
        };
        if (input.UpdateMethod != null)
        {
            response.UpdateMethod = MapMethodDefinition(input.UpdateMethod!);
        }
        return response;
    }

    private static MappingsDefinition MapMappingDefinitions(TerraformMappingDefinition input)
    {
        return new MappingsDefinition
        {
            Fields = MapFieldMappingDefinitions(input.Fields),
            ModelToModel = MapModelToModelMappingDefinitions(input.ModelToModel),
            ResourceId = input.ResourceIds.Select(MapResourceIdMappingDefinition).ToList(),
        };
    }

    private static List<ModelToModelMappingDefinition> MapModelToModelMappingDefinitions(List<TerraformModelToModelMappingDefinition> input)
    {
        return input.Select(i => new ModelToModelMappingDefinition
        {
            SchemaModelName = i.SchemaModelName,
            SdkModelName = i.SdkModelName,
        }).ToList();
    }

    private static List<FieldMappingDefinition> MapFieldMappingDefinitions(List<TerraformFieldMappingDefinition> input)
    {
        var mappings = new List<FieldMappingDefinition>();
        foreach (var mapping in input)
        {
            switch (mapping.Type)
            {
                case Data.Models.TerraformFieldMappingType.DirectAssignment:
                    {
                        mappings.Add(MapTerraformFieldDirectAssignmentMapping(mapping.DirectAssignment));
                        continue;
                    }

                case Data.Models.TerraformFieldMappingType.ModelToModel:
                    {
                        mappings.Add(MapTerraformFieldModelToModelMapping(mapping.ModelToModel));
                        continue;
                    }

                default:
                    {
                        throw new NotSupportedException($"mapping type ${mapping.Type.ToString()} is not implemented");
                    }
            }
        }
        return mappings;
    }

    private static FieldMappingDefinition MapTerraformFieldModelToModelMapping(TerraformFieldMappingModelToModelDefinition input)
    {
        return new FieldMappingDefinition
        {
            Type = TerraformFieldMappingType.ModelToModel.ToString(),
            ModelToModel = new FieldMappingModelToModelDefinition
            {
                SchemaModelName = input.SchemaModelName,
                SdkModelName = input.SdkModelName,
                SdkFieldName = input.SdkFieldName,
            },
        };
    }

    private static FieldMappingDefinition MapTerraformFieldDirectAssignmentMapping(TerraformFieldMappingDirectAssignmentDefinition input)
    {
        return new FieldMappingDefinition
        {
            Type = TerraformFieldMappingType.DirectAssignment.ToString(),
            DirectAssignment = new FieldMappingDirectAssignmentDefinition
            {
                SchemaModelName = input.SchemaModelName,
                SchemaFieldPath = input.SchemaFieldName,
                SdkModelName = input.SdkModelName,
                SdkFieldPath = input.SdkFieldName,
            },
        };
    }

    private static ResourceIdMappingDefinition MapResourceIdMappingDefinition(TerraformResourceIDMappingDefinition input)
    {
        return new ResourceIdMappingDefinition
        {
            SegmentName = input.SegmentName,
            SchemaFieldName = input.SchemaFieldName,
        };
    }

    private static TerraformResourceTestsDefinition MapTerraformResourceTests(TerraformResourceTestDefinition? input)
    {
        var definition = new TerraformResourceTestsDefinition
        {
            Generate = input != null,
        };

        if (input != null)
        {
            definition.BasicConfiguration = input.BasicConfig;
            definition.RequiresImportConfiguration = input.RequiresImportConfig;
            definition.CompleteConfiguration = input.CompleteConfig;
            definition.TemplateConfiguration = input.TemplateConfig;
            definition.OtherTests = input.OtherTests;
        }

        return definition;
    }

    private static Dictionary<string, TerraformSchemaDefinition> MapTerraformSchemaModels(Dictionary<string, TerraformSchemaModelDefinition> input)
    {
        var output = new Dictionary<string, TerraformSchemaDefinition>();

        foreach (var item in input)
        {
            output.Add(item.Key, MapSchemaModel(item.Value));
        }

        return output;
    }

    private static TerraformSchemaDefinition MapSchemaModel(TerraformSchemaModelDefinition input)
    {
        var fields = new Dictionary<string, TerraformSchemaFieldDefinition>();
        foreach (var field in input.Fields)
        {
            fields.Add(field.Key, MapTerraformSchemaField(field.Value));
        }

        return new TerraformSchemaDefinition
        {
            Fields = fields,
        };
    }

    private static TerraformSchemaFieldDefinition MapTerraformSchemaField(Data.Models.TerraformSchemaFieldDefinition input)
    {
        var objectDefinition = MapSchemaFieldObjectDefinition(input.ObjectDefinition);
        return new TerraformSchemaFieldDefinition
        {
            Computed = input.Computed,
            Documentation = new TerraformSchemaDocumentationDefinition
            {
                Markdown = input.Documentation.Markdown,
            },
            ForceNew = input.ForceNew,
            HclName = input.HclName,
            Optional = input.Optional,
            Required = input.Required,
            ObjectDefinition = objectDefinition,
            Validation = MapValidation(input.Validation),
        };
    }

    private static TerraformSchemaObjectDefinition MapSchemaFieldObjectDefinition(Data.Models.TerraformSchemaObjectDefinition input)
    {
        var output = new TerraformSchemaObjectDefinition
        {
            Type = MapSchemaFieldObjectDefinitionType(input.Type),
            ReferenceName = input.ReferenceName,
        };

        if (input.NestedObject != null)
        {
            output.NestedObject = MapSchemaFieldObjectDefinition(input.NestedObject!);
        }

        return output;
    }

    private static string MapSchemaFieldObjectDefinitionType(Data.Models.TerraformSchemaFieldType input)
    {
        switch (input)
        {
            case Data.Models.TerraformSchemaFieldType.Boolean:
                return TerraformSchemaFieldType.Boolean.ToString();
            case Data.Models.TerraformSchemaFieldType.DateTime:
                return TerraformSchemaFieldType.DateTime.ToString();
            case Data.Models.TerraformSchemaFieldType.Float:
                return TerraformSchemaFieldType.Float.ToString();
            case Data.Models.TerraformSchemaFieldType.Integer:
                return TerraformSchemaFieldType.Integer.ToString();
            case Data.Models.TerraformSchemaFieldType.List:
                return TerraformSchemaFieldType.List.ToString();
            case Data.Models.TerraformSchemaFieldType.Reference:
                return TerraformSchemaFieldType.Reference.ToString();
            case Data.Models.TerraformSchemaFieldType.Set:
                return TerraformSchemaFieldType.Set.ToString();
            case Data.Models.TerraformSchemaFieldType.String:
                return TerraformSchemaFieldType.String.ToString();

            case Data.Models.TerraformSchemaFieldType.EdgeZone:
                return TerraformSchemaFieldType.EdgeZone.ToString();
            case Data.Models.TerraformSchemaFieldType.IdentitySystemAssigned:
                return TerraformSchemaFieldType.IdentitySystemAssigned.ToString();
            case Data.Models.TerraformSchemaFieldType.IdentitySystemAndUserAssigned:
                return TerraformSchemaFieldType.IdentitySystemAndUserAssigned.ToString();
            case Data.Models.TerraformSchemaFieldType.IdentitySystemOrUserAssigned:
                return TerraformSchemaFieldType.IdentitySystemOrUserAssigned.ToString();
            case Data.Models.TerraformSchemaFieldType.IdentityUserAssigned:
                return TerraformSchemaFieldType.IdentityUserAssigned.ToString();
            case Data.Models.TerraformSchemaFieldType.Location:
                return TerraformSchemaFieldType.Location.ToString();
            case Data.Models.TerraformSchemaFieldType.ResourceGroup:
                return TerraformSchemaFieldType.ResourceGroup.ToString();
            case Data.Models.TerraformSchemaFieldType.Tags:
                return TerraformSchemaFieldType.Tags.ToString();
            case Data.Models.TerraformSchemaFieldType.Zone:
                return TerraformSchemaFieldType.Zone.ToString();
            case Data.Models.TerraformSchemaFieldType.Zones:
                return TerraformSchemaFieldType.Zones.ToString();
        }

        throw new NotSupportedException($"unmapped schema field type {input.ToString()}");
    }

    private static MethodDefinition MapMethodDefinition(TerraformMethodDefinition input)
    {
        return new MethodDefinition
        {
            Generate = input.Generate,
            MethodName = input.MethodName,
            TimeoutInMinutes = input.TimeoutInMinutes,
        };
    }

    private static TerraformSchemaFieldValidationDefinition? MapValidation(Data.Models.TerraformSchemaFieldValidationDefinition? input)
    {
        if (input == null)
        {
            return null;
        }

        if (input.Type != Data.Models.TerraformSchemaFieldValidationType.PossibleValues)
        {
            throw new NotSupportedException($"TODO: implement validation for {input.Type.ToString()}");
        }

        return new TerraformSchemaFieldValidationDefinition
        {
            Type = TerraformSchemaFieldValidation.PossibleValues.ToString(),
            PossibleValues = new TerraformSchemaFieldValidationPossibleValuesDefinition
            {
                Type = MapTerraformSchemaFieldValidationPossibleValueType(input.PossibleValues.Type),
                Values = input.PossibleValues.Values,
            },
        };
    }

    private static string MapTerraformSchemaFieldValidationPossibleValueType(TerraformSchemaFieldValidationPossibleType input)
    {
        switch (input)
        {
            case TerraformSchemaFieldValidationPossibleType.Float:
                return TerraformSchemaFieldValidationPossibleValueType.Float.ToString();

            case TerraformSchemaFieldValidationPossibleType.Int:
                return TerraformSchemaFieldValidationPossibleValueType.Int.ToString();

            case TerraformSchemaFieldValidationPossibleType.String:
                return TerraformSchemaFieldValidationPossibleValueType.String.ToString();
        }

        throw new NotSupportedException($"unimplemented validation type {input.ToString()}");
    }
}