using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Pandora.Api.Components.Api.V1.Helpers;
using Pandora.Data.Models;
using Pandora.Data.Repositories;

namespace Pandora.Api.V1.ResourceManagerOld
{
    [ApiController]
    public class TerraformFunctionsController : ControllerBase
    {
        private readonly IServiceReferencesRepository _repo;

        public TerraformFunctionsController(IServiceReferencesRepository repo)
        {
            _repo = repo;
        }

        [Route("/apis/v1/resource-manager/{serviceName}/terraform-resource/{resourceLabel}/functions")]
        public IActionResult ResourceManagerResource(string serviceName, string resourceLabel)
        {
            return TerraformFunctionInternal(serviceName, resourceLabel, true, false);
        }

        private IActionResult TerraformFunctionInternal(string serviceName, string resourceLabel, bool resourceManager, bool dataSource)
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

            var functions = resource.Functions.ToDictionary(f => MapFunctionType(f.FunctionType), f => MapFunction(f, serviceName, resourceManager));
            return new JsonResult(new FunctionsResponse
            {
                Functions = functions
            });
        }

        private static TerraformFunction MapFunction(TerraformFunctionDefinition input, string serviceName, bool resourceManager)
        {
            // TODO: we need to support multiple operations here in time
            var operation = input.Operations.First();
            var schemaObjectMapping = MapSchemaObjectMapping(input.Mapper, operation, serviceName, resourceManager);
            return new TerraformFunction
            {
                DefaultTimeoutInMinutes = input.DefaultTimeoutInMinutes,
                OperationName = operation.Name,
                SchemaObjectMapping = schemaObjectMapping,
            };
        }

        private static SchemaObjectMapping MapSchemaObjectMapping(TerraformSchemaMapperDefinition? mapper, OperationDefinition operation, string serviceName, bool resourceManager)
        {
            if (mapper == null)
            {
                return null;
            }
            
            var resourceType = resourceManager ? "data-source" : "resource-manager";
            var operationsUri = $"/apis/v1/{resourceType}/{serviceName}/{operation.ApiVersion}/{operation.ApiName}/operations";
            var objectName = mapper.Mappings.First().ObjectModelName;

            return new SchemaObjectMapping
            {
                // the operation doesn't necessarily belong in the same api version, so this is intentionally a reference not a name
                ObjectReference = SelfReference.To(operationsUri, objectName),
                Mappings = mapper.Mappings.ToDictionary(m => m.SchemaFieldPath, 
                    m => m.ObjectFieldPath),
            };
        }

        private static string MapFunctionType(TerraformFunctionType input)
        {
            switch (input)
            {
                case TerraformFunctionType.DataSourceRead:
                    return "data-source-read";
                
                case TerraformFunctionType.ResourceCreate:
                    return "resource-create";
                
                case TerraformFunctionType.ResourceDelete:
                    return "resource-delete";
                
                case TerraformFunctionType.ResourceRead:
                    return "resource-read";
                
                case TerraformFunctionType.ResourceUpdate:
                    return "resource-update";
            }
            
            throw new NotSupportedException($"unsupported function type {input.ToString()}");
        }

        private class FunctionsResponse
        {
            [JsonPropertyName("functions")]
            public Dictionary<string, TerraformFunction> Functions { get; set; }
        }

        private class TerraformFunction
        {
            [JsonPropertyName("defaultTimeoutInMinutes")]
            public int DefaultTimeoutInMinutes { get; set; }
            
            [JsonPropertyName("operationName")]
            public string OperationName { get; set; }
            
            [JsonPropertyName("schemaObjectMapping")]
            public SchemaObjectMapping? SchemaObjectMapping { get; set; }
        }

        private class SchemaObjectMapping
        {
            [JsonPropertyName("objectReference")]
            public string ObjectReference { get; set; }
            
            [JsonPropertyName("mappings")]
            public Dictionary<string, string> Mappings { get; set; }
        }
    }
}