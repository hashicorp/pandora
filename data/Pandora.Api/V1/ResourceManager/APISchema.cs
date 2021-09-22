using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Api.V1.Helpers;
using Pandora.Api.V1.Helpers;
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
                Models = api.Models.ToDictionary(m => m.Name, MapModel),
                ResourceIds = api.ResourceIds.ToDictionary(id => id.Name, MapResourceId),
            };
        }

        private class ModelApiDefinition
        {
            [JsonPropertyName("fields")]
            public Dictionary<string, PropertyApiDefinition> Fields { get; set; }

            [JsonPropertyName("parentTypeName")]
            public string? ParentTypeName { get; set; }

            [JsonPropertyName("typeHintIn")]
            public string? TypeHintIn { get; set; }

            [JsonPropertyName("typeHintValue")]
            public string? TypeHintValue { get; set; }
        }

        private static ModelApiDefinition MapModel(ModelDefinition model)
        {
            return new ModelApiDefinition
            {
                Fields = model.Properties.ToDictionary(p => p.Name, MapProperty),
                ParentTypeName = model.ParentTypeName,
                TypeHintIn = model.TypeHintIn,
                TypeHintValue = model.TypeHintValue,
            };
        }

        private static PropertyApiDefinition MapProperty(PropertyDefinition definition)
        {
            return new PropertyApiDefinition
            {
                ConstantReferenceName = definition.ConstantReference,
                DateFormat = definition.DateFormat,
                Default = definition.Default,
                IsTypeHint = definition.IsTypeHint,
                ForceNew = definition.ForceNew,
                JsonName = definition.JsonName,
                ListElementType = MapListElementType(definition.ListElementType),
                MinItems = definition.MinItems,
                MaxItems = definition.MaxItems,
                ModelReferenceName = definition.ModelReference,
                Optional = definition.Optional,
                PropertyType = MapApiPropertyType(definition.PropertyType),
                Required = definition.Required,
                Validation = ValidationApiDefinition.Map(definition.Validation),
            };
        }
        
        private static ResourceIdDefinition MapResourceId(Data.Models.ResourceIdDefinition id)
        {
            return new ResourceIdDefinition
            {
                // TODO: feed both Constant Names and Segments through
                ConstantNames = new List<string>(),
                Id = id.Format,
                Segments = new List<ResourceIdSegmentDefinition>(),
            };
        }

        private static string MapApiPropertyType(PropertyType input)
        {
            switch (input)
            {
                case PropertyType.Boolean:
                    return ApiPropertyType.Boolean.ToString();

                case PropertyType.Constant:
                    return ApiPropertyType.Constant.ToString();

                case PropertyType.DateTime:
                    return ApiPropertyType.DateTime.ToString();

                case PropertyType.Dictionary:
                    return ApiPropertyType.Dictionary.ToString();

                case PropertyType.Float:
                    return ApiPropertyType.Float.ToString();

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

                case PropertyType.SystemAssignedIdentity:
                    return ApiPropertyType.SystemAssignedIdentity.ToString();

                case PropertyType.SystemUserAssignedIdentityList:
                    return ApiPropertyType.SystemUserAssignedIdentityList.ToString();

                case PropertyType.SystemUserAssignedIdentityMap:
                    return ApiPropertyType.SystemUserAssignedIdentityMap.ToString();

                case PropertyType.UserAssignedIdentityList:
                    return ApiPropertyType.UserAssignedIdentityList.ToString();

                case PropertyType.UserAssignedIdentityMap:
                    return ApiPropertyType.UserAssignedIdentityMap.ToString();

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

            if (input.Value == PropertyType.Dictionary)
            {
                // technically it could, but there's no examples of this in the ARM API I've seen
                throw new NotSupportedException("A List/Dictionary Value cannot contain a Dictionary");
            }

            if (input.Value == PropertyType.List)
            {
                // technically it could, but there's no examples of this in the ARM API I've seen
                throw new NotSupportedException("A List/Dictionary Value cannot contain a list");
            }

            return MapApiPropertyType(input.Value);
        }

        private class ApiSchemaResponse
        {
            [JsonPropertyName("constants")]
            public Dictionary<string, ConstantApiDefinition> Constants { get; set; }

            [JsonPropertyName("models")]
            public Dictionary<string, ModelApiDefinition> Models { get; set; }

            [JsonPropertyName("resourceIds")]
            public Dictionary<string, ResourceIdDefinition> ResourceIds { get; set; }
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

            [JsonPropertyName("isTypeHint")]
            public bool IsTypeHint { get; set; }

            [JsonPropertyName("jsonName")]
            public string JsonName { get; set; }

            [JsonPropertyName("listElementType")]
            public string? ListElementType { get; set; }

            [JsonPropertyName("minItems")]
            public int? MinItems { get; set; }

            [JsonPropertyName("maxItems")]
            public int? MaxItems { get; set; }

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

        private class ResourceIdDefinition
        {
            [JsonPropertyName("constantNames")]
            public List<string> ConstantNames { get; set; }
            
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("segments")]
            public List<ResourceIdSegmentDefinition> Segments { get; set; }
        }

        private class ResourceIdSegmentDefinition
        {
            [JsonPropertyName("constantReference")]
            public string? ConstantReference { get; set; }
            
            [JsonPropertyName("fixedValue")]
            public string? FixedValue { get; set; }
            
            [JsonPropertyName("name")]
            public string Name { get; set; }
            
            [JsonPropertyName("type")]
            public string Type { get; set; }
        }

        private enum ApiPropertyType
        {
            // TODO: can we not back these with a string value in .net core
            Boolean,
            Constant,
            DateTime,
            Dictionary,
            Float,
            Integer,
            List,
            Location,
            Object,
            Tags,
            String,
            UserAssignedIdentityMap,
            UserAssignedIdentityList,
            SystemAssignedIdentity,
            SystemUserAssignedIdentityList,
            SystemUserAssignedIdentityMap,
        }
    }
}