using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManager;

[ApiController]
public class TerraformController : ControllerBase
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

        // TODO: Mappings should be an object containing `Type` (which allows us to pipe through `BooleanWhen` etc)

        return response;
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
            // TODO: Mappings & Validation
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

    private class TerraformV1Response
    {
        [JsonPropertyName("dataSources")]
        public Dictionary<string, DataSourceResponse> DataSources { get; set; }

        [JsonPropertyName("resources")]
        public Dictionary<string, ResourceResponse> Resources { get; set; }
    }

    private class DataSourceResponse
    {
        // TODO: stuff and things - don't forget to account for Single vs Plural DS's

        [JsonPropertyName("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonPropertyName("generate")]
        public bool Generate => GenerateModel || GenerateSchema || (PluralDetails?.Generate ?? false) || (SingularDetails?.Generate ?? false);

        [JsonPropertyName("generateModel")]
        public bool GenerateModel { get; set; }

        [JsonPropertyName("generateSchema")]
        public bool GenerateSchema { get; set; }

        [JsonPropertyName("plural")]
        public TerraformDataSourceTypeDetails? PluralDetails { get; set; }

        [JsonPropertyName("singular")]
        public TerraformDataSourceTypeDetails? SingularDetails { get; set; }

        // TODO: add other properties
    }

    private class TerraformDataSourceTypeDetails
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("exampleUsageHcl")]
        public string ExampleUsageHcl { get; set; }

        [JsonPropertyName("generate")]
        public bool Generate => GenerateModel || GenerateSchema || MethodDefinition.Generate;

        [JsonPropertyName("generateModel")]
        public bool GenerateModel { get; set; }

        [JsonPropertyName("generateSchema")]
        public bool GenerateSchema { get; set; }

        [JsonPropertyName("methodDefinition")]
        public MethodDefinition MethodDefinition { get; set; }

        [JsonPropertyName("resourceLabel")]
        public string ResourceLabel { get; set; }
    }

    private class ResourceResponse
    {
        // TODO: Schema [incl. Docs], Mappings, Tests etc
        [JsonPropertyName("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonPropertyName("createMethod")]
        public MethodDefinition CreateMethod { get; set; }

        [JsonPropertyName("deleteMethod")]
        public MethodDefinition DeleteMethod { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("documentation")]
        public ResourceDocumentationDefinition Documentation { get; set; }

        [JsonPropertyName("generate")]
        public bool Generate => DeleteMethod.Generate || GenerateModel || GenerateIdValidation || GenerateSchema;

        [JsonPropertyName("generateModel")]
        public bool GenerateModel { get; set; }

        [JsonPropertyName("generateIdValidation")]
        public bool GenerateIdValidation { get; set; }

        [JsonPropertyName("generateSchema")]
        public bool GenerateSchema { get; set; }

        [JsonPropertyName("readMethod")]
        public MethodDefinition ReadMethod { get; set; }

        [JsonPropertyName("resource")]
        public string Resource { get; set; }

        [JsonPropertyName("resourceIdName")]
        public string ResourceIdName { get; set; }

        [JsonPropertyName("resourceName")]
        public string ResourceName { get; set; }

        [JsonPropertyName("schemaModelName")]
        public string SchemaModelName { get; set; }

        [JsonPropertyName("schemaModels")]
        public Dictionary<string, TerraformSchemaDefinition> SchemaModels { get; set; }

        [JsonPropertyName("tests")]
        public TerraformResourceTestsDefinition Tests { get; set; }

        [JsonPropertyName("updateMethod")]
        public MethodDefinition? UpdateMethod { get; set; }
    }

    private class ResourceDocumentationDefinition
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("exampleUsageHcl")]
        public string ExampleUsageHcl { get; set; }
    }

    private class MethodDefinition
    {
        [JsonPropertyName("generate")]
        public bool Generate { get; set; }

        [JsonPropertyName("methodName")]
        public string MethodName { get; set; }

        [JsonPropertyName("timeoutInMinutes")]
        public int TimeoutInMinutes { get; set; }
    }

    private class TerraformSchemaDefinition
    {
        public Dictionary<string, TerraformSchemaFieldDefinition> Fields { get; set; }
    }

    private class TerraformSchemaObjectDefinition
    {
        [JsonPropertyName("nestedObject")]
        public TerraformSchemaObjectDefinition? NestedObject { get; set; }

        [JsonPropertyName("referenceName")]
        public string? ReferenceName { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    private class TerraformSchemaFieldDefinition
    {
        [JsonPropertyName("objectDefinition")]
        public TerraformSchemaObjectDefinition ObjectDefinition { get; set; }

        [JsonPropertyName("computed")]
        public bool Computed { get; set; }

        [JsonPropertyName("forceNew")]
        public bool ForceNew { get; set; }

        [JsonPropertyName("hclName")]
        public string HclName { get; set; }

        [JsonPropertyName("optional")]
        public bool Optional { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }

        [JsonPropertyName("documentation")]
        public TerraformSchemaDocumentationDefinition Documentation { get; set; }

        [JsonPropertyName("mappings")]
        public TerraformSchemaMappingDefinition Mappings { get; set; }

        [JsonPropertyName("validation")]
        public TerraformSchemaFieldValidationDefinition Validation { get; set; }
    }

    private class TerraformSchemaDocumentationDefinition
    {
        [JsonPropertyName("markdown")]
        public string Markdown { get; set; }
    }

    private class TerraformSchemaFieldValidationDefinition
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("possibleValues")]
        public List<string>? PossibleValues { get; set; }
    }

    private enum TerraformSchemaFieldType
    {
        // Core items
        Boolean,
        DateTime,
        Integer,
        Float,
        List,
        Reference,
        Set,
        String,

        // CommonSchema items
        EdgeZone,
        Location,
        IdentitySystemAssigned,
        IdentitySystemAndUserAssigned,
        IdentitySystemOrUserAssigned,
        IdentityUserAssigned,
        ResourceGroup,
        Tags,
        Zone,
        Zones,
        // NOTE: this intentionally doesn't contain the Legacy Identity Types since they're normalized in the schema
        // to the regular identity types
    }

    private enum TerraformSchemaFieldValidationType
    {
        NoEmptyValue,
        FixedValues,
        // TODO: ResourceID, Range etc
    }

    private class TerraformSchemaMappingDefinition
    {
        [JsonPropertyName("resourceIdSegment")]
        public string? ResourceIdSegment { get; set; }

        [JsonPropertyName("sdkPathForCreate")]
        public string? SDKPathForCreate { get; set; }

        [JsonPropertyName("sdkPathForRead")]
        public string? SDKPathForRead { get; set; }

        [JsonPropertyName("sdkPathForUpdate")]
        public string? SDKPathForUpdate { get; set; }

        // TODO: we'll probably want to change those to objects in time to handle things like
        // a `BooleanWhen` - e.g. for PrivateNetworkAccess where a const becomes a boolean
    }

    private class TerraformResourceTestsDefinition
    {
        [JsonPropertyName("basicConfiguration")]
        public string BasicConfiguration { get; set; }

        [JsonPropertyName("requiresImportConfiguration")]
        public string RequiresImportConfiguration { get; set; }

        [JsonPropertyName("completeConfiguration")]
        public string? CompleteConfiguration { get; set; }

        [JsonPropertyName("generate")]
        public bool Generate { get; set; }

        [JsonPropertyName("otherTests")]
        public Dictionary<string, List<string>> OtherTests { get; set; }

        [JsonPropertyName("templateConfiguration")]
        public string? TemplateConfiguration { get; set; }
    }
}
