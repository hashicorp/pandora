using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Api.V1.Helpers;
using Pandora.Api.V1.Helpers;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManagerOld
{
    [ApiController]
    public class TerraformSchemaController : ControllerBase
    {
        private readonly IServiceReferencesRepository _repo;

        public TerraformSchemaController(IServiceReferencesRepository repo)
        {
            _repo = repo;
        }
        
        [Route("/apis/v1/resource-manager/{serviceName}/terraform-resource/{resourceLabel}/schema")]
        public IActionResult ResourceManagerResource(string serviceName, string resourceLabel)
        {
            return TerraformSchemaInternal(serviceName, resourceLabel, true, false);
        }

        private IActionResult TerraformSchemaInternal(string serviceName, string resourceLabel, bool resourceManager, bool dataSource)
        {
            var service = _repo.GetByName(serviceName, resourceManager);
            if (service == null)
            {
                return NotFound();
            }

            var resourceList = dataSource ? service.DataSources : service.Resources;
            var resource = resourceList.FirstOrDefault(r => r.ResourceLabel == resourceLabel);
            if (resource == null)
            {
                return NotFound();
            }

            return new JsonResult(MapResponse(service, resource));
        }

        private static TerraformSchemaDefinitionResponse MapResponse(ServiceDefinition service, TerraformResourceDefinition resource)
        {
            var resourceType = resource.IsDataSource ? "data-source" : "resource";
            var schemaUri = $"/apis/v1/resource-manager/{service.Name}/terraform-{resourceType}/{resource.ResourceLabel}/schema";

            var constants = resource.Schema.Constants.ToDictionary(c => c.Name, ConstantApiDefinition.Map);
            var fields = resource.Schema.Fields.ToDictionary(f => f.Name, f => MapField(f, schemaUri));
            var models = resource.Schema.Models.ToDictionary(m => m.Name, m => MapModel(m, schemaUri));
            return new TerraformSchemaDefinitionResponse
            {
                Constants = constants,
                Fields = fields,
                Models = models,
            };
        }

        private static ModelDefinition MapModel(TerraformModelDefinition input, string schemaUri)
        {
            var fields = input.Fields.ToDictionary(f => f.Name, f => MapField(f, schemaUri));
            return new ModelDefinition
            {
                Fields = fields,
            };
        }

        private static FieldDefinition MapField(TerraformSchemaFieldDefinition input, string schemaUri)
        {
            var fieldType = MapFieldType(input.FieldType);
            var validationDefinition = ValidationApiDefinition.Map(input.Validation);
            var definition = new FieldDefinition
            {
                CaseInsensitive = input.CaseInsensitive,
                Computed = input.Computed,
                ConstantReference = SelfReference.To(schemaUri, input.ConstantType),
                Default = input.Default,
                FieldType = fieldType,
                ForceNew = input.ForceNew,
                HclLabel = input.HclLabel,
                MaxItems = input.MaxItems,
                MinItems = input.MinItems,
                ModelReference = SelfReference.To(schemaUri, input.ModelType),
                Optional = input.Optional,
                Required = input.Required,
                Validation = validationDefinition
            };

            return definition;
        }

        private class TerraformSchemaDefinitionResponse
        {
            [JsonPropertyName("constants")]
            public Dictionary<string, ConstantApiDefinition> Constants { get; set; }
            
            [JsonPropertyName("fields")]
            public Dictionary<string, FieldDefinition> Fields { get; set; }
            
            [JsonPropertyName("models")]
            public Dictionary<string, ModelDefinition> Models { get; set; }
        }
        
        private class FieldDefinition
        {
            [JsonPropertyName("caseInsensitive")]
            public bool CaseInsensitive { get; set; }
            
            [JsonPropertyName("computed")]
            public bool Computed { get; set; }
            
            [JsonPropertyName("constantReference")]
            public string? ConstantReference { get; set; }
            
            [JsonPropertyName("default")]
            public object? Default { get; set; }
            
            [JsonPropertyName("fieldType")]
            public string FieldType { get; set; }
            
            [JsonPropertyName("forceNew")]
            public bool ForceNew { get; set; }
            
            [JsonPropertyName("hclLabel")]
            public string HclLabel { get; set; }
            
            [JsonPropertyName("maxItems")]
            public int? MaxItems { get; set; }
            
            [JsonPropertyName("minItems")]
            public int? MinItems { get; set; }
            
            [JsonPropertyName("modelReference")]
            public string? ModelReference { get; set; }
            
            [JsonPropertyName("optional")]
            public bool Optional { get; set; }
            
            [JsonPropertyName("required")]
            public bool Required { get; set; }
        
            // TODO: public ResourceIdDefinition? ResourceIdReference { get; set; }
            
            [JsonPropertyName("validation")]
            public ValidationApiDefinition? Validation { get; set; }
        }
        
        private class ModelDefinition
        {
            [JsonPropertyName("fields")]
            public Dictionary<string, FieldDefinition> Fields { get; set; }
        }

        private static string MapFieldType(TerraformFieldType input)
        {
            switch (input)
            {
                case TerraformFieldType.Boolean:
                    return "boolean";
                
                case TerraformFieldType.Float:
                    return "float";
                
                case TerraformFieldType.Integer:
                    return "integer";
                
                case TerraformFieldType.List:
                    return "list";
                
                case TerraformFieldType.Location:
                    return "location";
                
                case TerraformFieldType.Set:
                    return "set";
                
                case TerraformFieldType.String:
                    return "string";
                
                case TerraformFieldType.Tags:
                    return "tags";
            }
            
            throw new NotSupportedException($"unsupported field type {input.ToString()}");
        }
    }
}