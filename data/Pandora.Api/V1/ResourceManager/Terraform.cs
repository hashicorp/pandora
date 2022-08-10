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
        };
        if (input.UpdateMethod != null)
        {
            response.UpdateMethod = MapMethodDefinition(input.UpdateMethod!);
        }

        // TODO: Mappings should be an object containing `Type` (which allows us to pipe through `BooleanWhen` etc)

        // TODO: replace these with real mappings
        if (input.ResourceLabel == "resource_group")
        {
            response.SchemaModelName = $"{input.ResourceName}ResourceSchema";
            response.SchemaModels = new Dictionary<string, TerraformSchemaDefinition>
            {
                {$"{input.ResourceName}ResourceSchema", new TerraformSchemaDefinition
                {
                    Fields = new Dictionary<string, TerraformSchemaFieldDefinition>
                    {
                        {"Name", new TerraformSchemaFieldDefinition
                        {
                            Computed = false,
                            Optional = false,
                            Required = true,
                            ForceNew = true,
                            HclName = "name",
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.ResourceGroup.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "The name of this Resource Group."
                            },
                            Validation = new TerraformSchemaFieldValidationDefinition
                            {
                                Type = TerraformSchemaFieldValidationType.NoEmptyValue.ToString(),
                            },
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                ResourceIdSegment = "resourceGroupName"
                            },
                        }},
                        {"Location", new TerraformSchemaFieldDefinition
                        {
                            HclName = "location",
                            Computed = false,
                            Optional = false,
                            Required = true,
                            ForceNew = true,
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.Location.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "The Azure Region where this Resource Group should be created."
                            },
                            Validation = new TerraformSchemaFieldValidationDefinition
                            {
                                Type = TerraformSchemaFieldValidationType.NoEmptyValue.ToString(),
                            },
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                SDKPathForCreate = "Location",
                                SDKPathForRead = "Location",
                                SDKPathForUpdate = null,
                            },
                        }},
                        {"Tags", new TerraformSchemaFieldDefinition
                        {
                            HclName = "tags",
                            Computed = false,
                            Optional = true,
                            Required = false,
                            ForceNew = false,
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.Tags.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "A mapping of tags which should be assigned to this Resource Group."
                            },
                            Validation = null,
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                SDKPathForCreate = "Tags",
                                SDKPathForRead = "Tags",
                                SDKPathForUpdate = "Tags",
                            },
                        }}
                    }
                }},
            };
            response.Tests = new TerraformResourceTestsDefinition
            {
                Generate = true,
                BasicConfiguration = @"
resource ""azurerm_resource_group"" ""test"" {
    name     = ""acctest-rg${local.random_integer}""
    location = local.primary_location
}
",
                CompleteConfiguration = @"
resource ""azurerm_resource_group"" ""test"" {
    name     = ""acctest-rg${local.random_integer}""
    location = local.primary_location

    tags = {
        ""Hello"" = ""AutoGen""
    }
}
",
                RequiresImportConfiguration = @"
resource ""azurerm_resource_group"" ""import"" {
    name     = azurerm_resource_group.test.name
    location = azurerm_resource_group.test.location
}
",
            };
        }

        if (input.ResourceLabel == "virtual_machine")
        {
            response.SchemaModelName = $"{input.ResourceName}ResourceSchema";
            response.SchemaModels = new Dictionary<string, TerraformSchemaDefinition>
            {
                {$"{input.ResourceName}ResourceSchema", new TerraformSchemaDefinition
                {
                    Fields = new Dictionary<string, TerraformSchemaFieldDefinition>
                    {
                        {"Name", new TerraformSchemaFieldDefinition
                        {
                            HclName = "name",
                            Computed = false,
                            Optional = false,
                            Required = true,
                            ForceNew = true,
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.String.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "The name of this Virtual Machine."
                            },
                            Validation = new TerraformSchemaFieldValidationDefinition
                            {
                                Type = TerraformSchemaFieldValidationType.NoEmptyValue.ToString(),
                            },
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                ResourceIdSegment = "virtualMachineName"
                            },
                        }},
                        {"ResourceGroupName", new TerraformSchemaFieldDefinition
                        {
                            HclName = "resource_group_name",
                            Computed = false,
                            Optional = false,
                            Required = true,
                            ForceNew = true,
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.String.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "The name of the Resource Group that this Virtual Machine is located within."
                            },
                            Validation = new TerraformSchemaFieldValidationDefinition
                            {
                                Type = TerraformSchemaFieldValidationType.NoEmptyValue.ToString(),
                            },
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                ResourceIdSegment = "resourceGroupName"
                            },
                        }},
                        {"Location", new TerraformSchemaFieldDefinition
                        {
                            HclName = "location",
                            Computed = false,
                            Optional = false,
                            Required = true,
                            ForceNew = true,
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.Location.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "The Azure Region where this Resource Group should be created."
                            },
                            Validation = new TerraformSchemaFieldValidationDefinition
                            {
                                Type = TerraformSchemaFieldValidationType.NoEmptyValue.ToString(),
                            },
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                SDKPathForCreate = "Location",
                                SDKPathForRead = "Location",
                                SDKPathForUpdate = null,
                            },
                        }},
                        {"Tags", new TerraformSchemaFieldDefinition
                        {
                            HclName = "tags",
                            Computed = false,
                            Optional = true,
                            Required = false,
                            ForceNew = false,
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.Tags.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "A mapping of tags which should be assigned to this Resource Group."
                            },
                            Validation = null,
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                SDKPathForCreate = "Tags",
                                SDKPathForRead = "Tags",
                                SDKPathForUpdate = "Tags",
                            },
                        }},
                        {"NestedItem", new TerraformSchemaFieldDefinition
                        {
                            HclName = "nested_item",
                            Optional = true,
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "Something. I don't know.",
                            },
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.Reference.ToString(),
                                ReferenceName = $"{input.ResourceName}AddressSchema",
                            },
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                SDKPathForCreate = "Properties.NestedItem",
                                SDKPathForRead = "Properties.NestedItem",
                                SDKPathForUpdate = "Properties.NestedItem",
                            },
                        }},
                    }
                }},
                {
                    $"{input.ResourceName}AddressSchema", new TerraformSchemaDefinition
                    {
                        Fields = new Dictionary<string, TerraformSchemaFieldDefinition>
                        {
                            {"Line1", new TerraformSchemaFieldDefinition
                            {
                                HclName = "line1",
                                Computed = false,
                                Optional = false,
                                Required = true,
                                ForceNew = true,
                                ObjectDefinition = new TerraformSchemaObjectDefinition
                                {
                                    Type = TerraformSchemaFieldType.String.ToString(),
                                },
                                Documentation = new TerraformSchemaDocumentationDefinition
                                {
                                    Markdown = "The first line of the address."
                                },
                                Validation = new TerraformSchemaFieldValidationDefinition
                                {
                                    Type = TerraformSchemaFieldValidationType.NoEmptyValue.ToString(),
                                },
                                Mappings = new TerraformSchemaMappingDefinition
                                {
                                    SDKPathForCreate = "Line1",
                                    SDKPathForRead = "Line1",
                                    SDKPathForUpdate = "Line1",
                                },
                            }},
                            {"TownOrCity", new TerraformSchemaFieldDefinition
                            {
                                HclName = "town_or_city",
                                Computed = false,
                                Optional = false,
                                Required = true,
                                ForceNew = true,
                                ObjectDefinition = new TerraformSchemaObjectDefinition
                                {
                                    Type = TerraformSchemaFieldType.String.ToString(),
                                },
                                Documentation = new TerraformSchemaDocumentationDefinition
                                {
                                    Markdown = "The town or city of the address."
                                },
                                Validation = new TerraformSchemaFieldValidationDefinition
                                {
                                    Type = TerraformSchemaFieldValidationType.NoEmptyValue.ToString(),
                                },
                                Mappings = new TerraformSchemaMappingDefinition
                                {
                                    SDKPathForCreate = "TownOrCity",
                                    SDKPathForRead = "TownOrCity",
                                    SDKPathForUpdate = "TownOrCity",
                                },
                            }}
                        }
                    }
                }
            };
            response.Tests = new TerraformResourceTestsDefinition
            {
                Generate = true,
                BasicConfiguration = @"
resource ""azurerm_virtual_machine"" ""test"" {
    name     = ""acctest-vm${local.random_integer}""
    location = local.primary_location
}
",
                CompleteConfiguration = @"
resource ""azurerm_virtual_machine"" ""test"" {
    name     = ""acctest-vm${local.random_integer}""
    location = local.primary_location

    tags = {
        ""Hello"" = ""AutoGen""
    }
}
",
                RequiresImportConfiguration = @"
resource ""azurerm_virtual_machine"" ""import"" {
    name     = azurerm_virtual_machine.test.name
    location = azurerm_virtual_machine.test.location
}
",
            };
        }

        if (input.ResourceLabel == "virtual_machine_scale_set")
        {
            response.SchemaModelName = $"{input.ResourceName}ResourceSchema";
            response.SchemaModels = new Dictionary<string, TerraformSchemaDefinition>
            {
                {$"{input.ResourceName}ResourceSchema", new TerraformSchemaDefinition
                {
                    Fields = new Dictionary<string, TerraformSchemaFieldDefinition>
                    {
                        {"Name", new TerraformSchemaFieldDefinition
                        {
                            HclName = "name",
                            Computed = false,
                            Optional = false,
                            Required = true,
                            ForceNew = true,
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.String.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "The name of this Virtual Machine Scale Set."
                            },
                            Validation = new TerraformSchemaFieldValidationDefinition
                            {
                                Type = TerraformSchemaFieldValidationType.NoEmptyValue.ToString(),
                            },
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                ResourceIdSegment = "virtualMachineScaleSetName"
                            },
                        }},
                        {"ResourceGroupName", new TerraformSchemaFieldDefinition
                        {
                            HclName = "resource_group_name",
                            Computed = false,
                            Optional = false,
                            Required = true,
                            ForceNew = true,
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.String.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "The name of the Resource Group that this Virtual Machine Scale Set is located within."
                            },
                            Validation = new TerraformSchemaFieldValidationDefinition
                            {
                                Type = TerraformSchemaFieldValidationType.NoEmptyValue.ToString(),
                            },
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                ResourceIdSegment = "resourceGroupName"
                            },
                        }},
                        {"Location", new TerraformSchemaFieldDefinition
                        {
                            HclName = "location",
                            Computed = false,
                            Optional = false,
                            Required = true,
                            ForceNew = true,
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.Location.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "The Azure Region where this Resource Group should be created."
                            },
                            Validation = new TerraformSchemaFieldValidationDefinition
                            {
                                Type = TerraformSchemaFieldValidationType.NoEmptyValue.ToString(),
                            },
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                SDKPathForCreate = "Location",
                                SDKPathForRead = "Location",
                                SDKPathForUpdate = null,
                            },
                        }},
                        {"Tags", new TerraformSchemaFieldDefinition
                        {
                            HclName = "tags",
                            Computed = false,
                            Optional = true,
                            Required = false,
                            ForceNew = false,
                            ObjectDefinition = new TerraformSchemaObjectDefinition
                            {
                                Type = TerraformSchemaFieldType.Tags.ToString(),
                            },
                            Documentation = new TerraformSchemaDocumentationDefinition
                            {
                                Markdown = "A mapping of tags which should be assigned to this Resource Group."
                            },
                            Validation = null,
                            Mappings = new TerraformSchemaMappingDefinition
                            {
                                SDKPathForCreate = "Tags",
                                SDKPathForRead = "Tags",
                                SDKPathForUpdate = "Tags",
                            },
                        }}
                    }
                }},
            };
            response.Tests = new TerraformResourceTestsDefinition
            {
                Generate = true,
                BasicConfiguration = @"
resource ""azurerm_virtual_machine_scale_set"" ""test"" {
    name     = ""acctest-vmss${local.random_integer}""
    location = local.primary_location
}
",
                CompleteConfiguration = @"
resource ""azurerm_virtual_machine_scale_set"" ""test"" {
    name     = ""acctest-vmss${local.random_integer}""
    location = local.primary_location

    tags = {
        ""Hello"" = ""AutoGen""
    }
}
",
                RequiresImportConfiguration = @"
resource ""azurerm_virtual_machine_scale_set"" ""import"" {
    name     = azurerm_virtual_machine_scale_set.test.name
    location = azurerm_virtual_machine_scale_set.test.location
}
",
            };
        }

        return response;
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
