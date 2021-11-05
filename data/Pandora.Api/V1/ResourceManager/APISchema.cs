using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                DateFormat = definition.DateFormat,
                Default = definition.Default,
                ForceNew = definition.ForceNew,
                JsonName = definition.JsonName,
                IsTypeHint = definition.IsTypeHint,
                ObjectDefinition = ApiObjectDefinitionMapper.Map(definition.ObjectDefinition),
                Optional = definition.Optional,
                Required = definition.Required,
                Validation = ValidationApiDefinition.Map(definition.Validation),
            };
        }

        private static ResourceIdDefinition MapResourceId(Data.Models.ResourceIdDefinition id)
        {
            var uniqueConstantNames = id.Segments.Where(s => s.ConstantReference != null).Select(s => s.ConstantReference!).Distinct().ToList();
            var segments = id.Segments.Select(MapResourceIdSegment).ToList();
            return new ResourceIdDefinition
            {
                CommonAlias = id.CommonAlias,
                ConstantNames = uniqueConstantNames,
                Id = id.IdString,
                Segments = segments,
            };
        }

        private static ResourceIdSegmentDefinition MapResourceIdSegment(Data.Models.ResourceIdSegmentDefinition input)
        {
            var segmentType = MapResourceIdSegmentType(input.Type);
            return new ResourceIdSegmentDefinition
            {
                ConstantReference = input.ConstantReference,
                ExampleValue = input.ExampleValue,
                FixedValue = input.FixedValue,
                Name = input.Name,
                Type = segmentType,
            };
        }

        private static string MapResourceIdSegmentType(Data.Models.ResourceIdSegmentType input)
        {
            switch (input)
            {
                case Data.Models.ResourceIdSegmentType.Constant:
                    return ResourceIdSegmentType.Constant.ToString();

                case Data.Models.ResourceIdSegmentType.ResourceGroup:
                    return ResourceIdSegmentType.ResourceGroup.ToString();

                case Data.Models.ResourceIdSegmentType.ResourceProvider:
                    return ResourceIdSegmentType.ResourceProvider.ToString();

                case Data.Models.ResourceIdSegmentType.Scope:
                    return ResourceIdSegmentType.Scope.ToString();

                case Data.Models.ResourceIdSegmentType.Static:
                    return ResourceIdSegmentType.Static.ToString();

                case Data.Models.ResourceIdSegmentType.SubscriptionId:
                    return ResourceIdSegmentType.SubscriptionId.ToString();

                case Data.Models.ResourceIdSegmentType.UserSpecified:
                    return ResourceIdSegmentType.UserSpecified.ToString();

                default:
                    throw new NotImplementedException($"unsupported value {input.ToString()}");
            }
        }

        public enum ResourceIdSegmentType
        {
            Constant,
            ResourceGroup,
            ResourceProvider,
            Scope,
            Static,
            SubscriptionId,
            UserSpecified
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

            [JsonPropertyName("objectDefinition")]
            public ApiObjectDefinition ObjectDefinition { get; set; }

            [JsonPropertyName("optional")]
            public bool Optional { get; set; }

            [JsonPropertyName("required")]
            public bool Required { get; set; }

            [JsonPropertyName("validation")]
            public ValidationApiDefinition? Validation { get; set; }
        }

        private class ResourceIdDefinition
        {
            [JsonPropertyName("commonAlias")]
            public string? CommonAlias { get; set; }
        
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

            [JsonPropertyName("exampleValue")]
            public string ExampleValue { get; set; }

            [JsonPropertyName("fixedValue")]
            public string? FixedValue { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }
        }
    }
}