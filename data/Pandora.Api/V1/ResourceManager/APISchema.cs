using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Api.Components.Api.V1.Helpers;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManager
{
    [ApiController]
    public class ApiSchemaController : ControllerBase
    {
        private readonly IServiceReferencesRepository _repo;

        public ApiSchemaController(IServiceReferencesRepository repo)
        {
            _repo = repo;
        }

        [Route("/v1/resource-manager/services/{serviceName}/{apiVersion}/{apiName}/schema")]
        public IActionResult ResourceManager(string serviceName, string apiVersion, string apiName)
        {
            return ForService(serviceName, apiVersion, apiName, true);
        }

        private IActionResult ForService(string serviceName, string apiVersion, string apiName, bool resourceManager)
        {
            var service = _repo.GetByName(serviceName, resourceManager);
            if (service == null)
            {
                return BadRequest("service not found");
            }

            var version = service.Versions.FirstOrDefault(v => v.Version == apiVersion);
            if (version == null)
            {
                return BadRequest($"version {apiVersion} was not found");
            }

            var api = version.Apis.FirstOrDefault(a => a.Name == apiName);
            if (api == null)
            {
                return BadRequest($"api {apiName} was not found");
            }

            return new JsonResult(MapResponse(api, version, service, resourceManager));
        }

        private static ApiSchemaResponse MapResponse(ApiDefinition api, VersionDefinition version, ServiceDefinition service, bool resourceManager)
        {
            return new ApiSchemaResponse
            {
                Constants = api.Constants.ToDictionary(c => c.Name, ConstantApiDefinition.Map),
                Models = api.Models.ToDictionary(m => m.Name, MapModel)
            };
        }

        private class ModelApiDefinition
        {
            [JsonPropertyName("fields")]
            public Dictionary<string, PropertyApiDefinition> Fields { get; set; }
        }

        private static ModelApiDefinition MapModel(ModelDefinition model)
        {
            return new ModelApiDefinition
            {
                Fields = model.Properties.ToDictionary(p => p.Name, MapProperty), 
            };
        }

        private static PropertyApiDefinition MapProperty(PropertyDefinition definition)
        {
            return new PropertyApiDefinition
            {
                ConstantReferenceName = definition.ConstantReference,
                DateFormat = definition.DateFormat,
                Default = definition.Default,
                JsonName = definition.JsonName,
                ListElementType = MapListElementType(definition.ListElementType),
                ModelReferenceName = definition.ModelReference,
                Optional = definition.Optional,
                PropertyType = MapApiPropertyType(definition.PropertyType),
                Required = definition.Required,
                ForceNew = definition.ForceNew,
                Validation = ValidationApiDefinition.Map(definition.Validation),
            };
        }

        private static string MapApiPropertyType(PropertyType input)
        {
            switch (input)
            {
                // TODO: Dates and Dictionaries
                
                case PropertyType.Boolean:
                    return ApiPropertyType.Boolean.ToString();
                
                case PropertyType.Constant:
                    return ApiPropertyType.Constant.ToString();
                
                case PropertyType.DateTime:
                    return ApiPropertyType.DateTime.ToString();
                
                case PropertyType.Integer:
                    return ApiPropertyType.Integer.ToString();
                
                case PropertyType.List:
                    return ApiPropertyType.List.ToString();
                
                case PropertyType.Location:
                    return ApiPropertyType.Location.ToString();
                
                case PropertyType.Object:
                    return ApiPropertyType.Object.ToString();
                
                case PropertyType.String:
                    return ApiPropertyType.String.ToString();
                
                case PropertyType.Tags:
                    return ApiPropertyType.Tags.ToString();
                
                default:
                    throw new NotImplementedException($"unsupported value {input.ToString()}");
            }
        }

        private static string? MapListElementType(PropertyType? input)
        {
            if (input == null)
            {
                return null;
            }

            if (input.Value == PropertyType.List)
            {
                // technically it could, but there's no examples of this in the ARM API I've seen
                throw new NotSupportedException("A List cannot contain a list");
            }

            return MapApiPropertyType(input.Value);
        }

        private class ApiSchemaResponse
        {
            [JsonPropertyName("constants")]
            public Dictionary<string, ConstantApiDefinition> Constants { get; set; }

            [JsonPropertyName("models")]
            public Dictionary<string, ModelApiDefinition> Models { get; set; }
        }

        private class PropertyApiDefinition
        {
            [JsonPropertyName("constantReferenceName")]
            public string ConstantReferenceName { get; set; }
            
            [JsonPropertyName("dateFormat")]
            public string? DateFormat { get; set; }
        
            [JsonPropertyName("default")]
            public object? Default { get; set; }
            
            // TODO: should this be renamed Immutable?
            [JsonPropertyName("forceNew")]
            public bool ForceNew { get; set; }

            [JsonPropertyName("jsonName")]
            public string JsonName { get; set; }

            [JsonPropertyName("listElementType")]
            public string? ListElementType { get; set; }
        
            [JsonPropertyName("modelReferenceName")]
            public string ModelReferenceName { get; set; }
        
            [JsonPropertyName("optional")]
            public bool Optional { get; set; }
        
            [JsonPropertyName("required")]
            public bool Required { get; set; }
            
            [JsonPropertyName("type")]
            public string PropertyType { get; set; }
        
            [JsonPropertyName("validation")]
            public ValidationApiDefinition? Validation { get; set; }
        }

        private enum ApiPropertyType
        {
            // TODO: can we not back these with a string value in .net core
            Boolean,
            Constant,
            DateTime,
            Integer,
            List,
            Location,
            Object,
            Tags,
            String,
        }
    }
}