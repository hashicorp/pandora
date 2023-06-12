using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pandora.Api.V1.Controllers;

public partial class TerraformController
{
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

        [JsonPropertyName("mappings")]
        public MappingsDefinition Mappings { get; set; }

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
        public TerraformSchemaFieldValidationPossibleValuesDefinition? PossibleValues { get; set; }
    }

    private class TerraformSchemaFieldValidationPossibleValuesDefinition
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("values")]
        public List<object>? Values { get; set; }
    }

    private enum TerraformSchemaFieldType
    {
        // Core items
        Boolean,
        DateTime,
        Dictionary,
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

    private class ResourceIdMappingDefinition
    {
        [JsonPropertyName("schemaFieldName")]
        public string SchemaFieldName { get; set; }

        [JsonPropertyName("segmentName")]
        public string SegmentName { get; set; }
    }

    private class MappingsDefinition
    {
        // TODO: should we add a Generate flag to this?

        [JsonPropertyName("fields")]
        public List<FieldMappingDefinition> Fields { get; set; }

        [JsonPropertyName("modelToModel")]
        public List<ModelToModelMappingDefinition> ModelToModel { get; set; }

        [JsonPropertyName("resourceId")]
        public List<ResourceIdMappingDefinition> ResourceId { get; set; }
    }

    private class ModelToModelMappingDefinition
    {
        [JsonPropertyName("schemaModelName")]
        public string SchemaModelName { get; set; }

        [JsonPropertyName("sdkModelName")]
        public string SdkModelName { get; set; }
    }

    private class FieldMappingDefinition
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("directAssignment")]
        public FieldMappingDirectAssignmentDefinition? DirectAssignment { get; set; }

        [JsonPropertyName("modelToModel")]
        public FieldMappingModelToModelDefinition? ModelToModel { get; set; }

        // TODO: BooleanEquals, Manual etc
    }

    private class FieldMappingDirectAssignmentDefinition
    {
        /// <summary>
        /// SchemaModelName is the name of the Schema Model
        /// </summary>
        [JsonPropertyName("schemaModelName")]
        public string SchemaModelName { get; set; }

        /// <summary>
        /// SchemaFieldPath is the path to the field within the SchemaModelName (e.g. `Foo` or `Foo.Bar`)
        /// </summary>
        [JsonPropertyName("schemaFieldPath")]
        public string? SchemaFieldPath { get; set; }

        /// <summary>
        /// SdkModelName is the name of the Sdk Model associated with this mapping.
        /// </summary>
        [JsonPropertyName("sdkModelName")]
        public string SdkModelName { get; set; }

        /// <summary>
        /// SdkFieldPath is the path to the field within the Sdk Model
        /// </summary>
        [JsonPropertyName("sdkFieldPath")]
        public string? SdkFieldPath { get; set; }
    }

    private class FieldMappingModelToModelDefinition
    {
        /// <summary>
        /// SchemaModelName specifies the name of the Schema Model used for this ModelToModel Mapping.
        /// </summary>
        [JsonPropertyName("schemaModelName")]
        public string SchemaModelName { get; set; }

        /// <summary>
        /// SdkModelName specifies the name of the Sdk Model used for this ModelToModel Mapping. 
        /// </summary>
        [JsonPropertyName("sdkModelName")]
        public string SdkModelName { get; set; }

        /// <summary>
        /// SdkFieldName specifies the name of the Field within the Sdk Model
        /// </summary>
        [JsonPropertyName("sdkFieldName")]
        public string SdkFieldName { get; set; }
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

    private enum TerraformSchemaFieldValidationPossibleValueType
    {
        Float,
        Int,
        String,
    }

    private enum TerraformSchemaFieldValidation
    {
        PossibleValues,
    }

    private enum TerraformFieldMappingType
    {
        DirectAssignment,
        ModelToModel,
        // TODO: Manual, BooleanEquals etc
    }
}
