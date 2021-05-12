using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Api.V1.Helpers;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManagerOld
{
    [ApiController]
    public class TerraformResourcesController : ControllerBase
    {
        private readonly IServiceReferencesRepository _repo;

        public TerraformResourcesController(IServiceReferencesRepository repo)
        {
            _repo = repo;
        }
        
        [Route("/apis/v1/resource-manager/{serviceName}/terraform-resource/{resourceLabel}")]
        public IActionResult ResourceManagerResource(string serviceName, string resourceLabel)
        {
            return TerraformResourceInternal(serviceName, resourceLabel, true, false);
        }

        private IActionResult TerraformResourceInternal(string serviceName, string resourceLabel, bool resourceManager, bool dataSource)
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

            return new JsonResult(MapResponse(service, resource, resourceManager));
        }

        private static TerraformResourceDefinitionResponse MapResponse(ServiceDefinition service, TerraformResourceDefinition resource, bool resourceManager)
        {
            var apiType = resourceManager ? "resource-manager" : "data-plane";
            var resourceType = resource.IsDataSource ? "data-source" : "resource";
            var thisUri = $"/apis/v1/{apiType}/{service.Name}/terraform-{resourceType}/{resource.ResourceLabel}";
            var resourceId = $"/apis/v1/{apiType}/{service.Name}/{resource.ApiDefinition.ApiVersion}/{resource.ApiDefinition.Name}";
            var schemaToResourceIdMapping = MapSchemaToResourceIDMapping(resource.SchemaToResourceIdMapping, resourceId);
            return new TerraformResourceDefinitionResponse
            {
                Name = resource.Name,
                FunctionsUri = $"{thisUri}/functions",
                IsDataSource = resource.IsDataSource,
                Label = resource.ResourceLabel,
                ResourceId = new Helpers.LegacyResourceId(resource.ResourceId),
                SchemaToResourceIdMapping = schemaToResourceIdMapping,
                SchemaUri = $"{thisUri}/schema",
                TestsUri = $"{thisUri}/tests"
            };
        }

        private static SchemaToResourceIdMapping MapSchemaToResourceIDMapping(Data.Models.SchemaToResourceIdMapping input, string resourceUri)
        {
            var selfReference = SelfReference.To(resourceUri, input.ResourceIdType);
            return new SchemaToResourceIdMapping
            {
                ResourceIdReference = selfReference,
                SegmentMapping = input.SegmentMapping,
            };
        }

        private class TerraformResourceDefinitionResponse
        {
            [JsonPropertyName("functionsUri")]
            public string FunctionsUri { get; set; }
            
            [JsonPropertyName("isDataSource")]
            public bool IsDataSource { get; set; }
            
            [JsonPropertyName("label")]
            public string Label { get; set; }
            
            [JsonPropertyName("name")]
            public string Name { get; set; }
            
            [JsonPropertyName("resourceId")]
            public Helpers.LegacyResourceId ResourceId { get; set; }
            
            [JsonPropertyName("schemaToResourceIdMapping")]
            public SchemaToResourceIdMapping SchemaToResourceIdMapping { get; set; }

            [JsonPropertyName("schemaUri")]
            public string SchemaUri { get; set; }

            [JsonPropertyName("testsUri")]
            public string TestsUri { get; set; }
        }

        private class SchemaToResourceIdMapping
        {
            [JsonPropertyName("resourceIdReference")]
            public string ResourceIdReference { get; set; }
            
            [JsonPropertyName("segmentMappings")]
            public List<string> SegmentMapping { get; set; } 
        }
    }
}