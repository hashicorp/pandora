using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Api.V1.Helpers;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.Controllers;

public class CommonTypesController : ControllerBase
{
    private readonly ICommonTypesRepository _repo;

    public CommonTypesController(ICommonTypesRepository repo)
    {
        _repo = repo;
    }

    [Route("/v1/microsoft-graph/{apiVersion}/commonTypes")]
    public IActionResult MicrosoftGraph(string apiVersion)
    {
        var definitionType = apiVersion.ParseServiceDefinitionTypeFromApiVersion();
        if (definitionType == null)
        {
            return BadRequest($"the API Version {apiVersion} is not supported");
        }

        return CommonTypes(definitionType.Value);
    }

    private IActionResult CommonTypes(ServiceDefinitionType serviceDefinitionType)
    {
        var commonTypes = _repo.Get(serviceDefinitionType);
        return new JsonResult(MapResponse(commonTypes));
    }

    private class CommonTypesResponse
    {
        [JsonPropertyName("constants")]
        public Dictionary<string, ConstantApiDefinition> Constants { get; set; }

        [JsonPropertyName("models")]
        public Dictionary<string, ModelApiDefinition> Models { get; set; }

        [JsonPropertyName("resourceIds")]
        public Dictionary<string, ResourceIdDefinition> ResourceIds { get; set; }
    }

    private static CommonTypesResponse MapResponse(IEnumerable<CommonTypesDefinition> resource)
    {
        var constants = resource.SelectMany(c => c.Constants);
        var models = resource.SelectMany(c => c.Models);

        return new CommonTypesResponse
        {
            Constants = constants.ToDictionary(c => c.Name, ConstantApiDefinition.Map),
            Models = models.ToDictionary(m => m.Name, MapModel),
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

    private class PropertyApiDefinition
    {
        [JsonPropertyName("dateFormat")]
        public string? DateFormat { get; set; }

        [JsonPropertyName("default")]
        public object? Default { get; set; }

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
}
