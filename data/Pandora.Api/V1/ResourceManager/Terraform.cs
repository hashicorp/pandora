using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
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

    [Route("/v1/resource-manager/services/{serviceName}/{apiVersion}/terraform")]
    public IActionResult Terraform(string serviceName, string apiVersion)
    {
        if (serviceName == "Resources" && apiVersion == "2020-06-01")
        {
            // NOTE: fake placeholder data for now to build against
            return new JsonResult(new TerraformV1Response
            {
                DataSources = new Dictionary<string, DataSourceResponse>(),
                Resources = new Dictionary<string, ResourceResponse>
                {
                    {
                        "resource_group", new ResourceResponse
                        {
                            DeleteMethod = new MethodDefinition
                            {
                                Generate = true,
                                MethodName = "Delete",
                                TimeoutInMinutes = 30,
                            },
                            DisplayName = "Resource Group",
                            GenerateSchema = false,
                            GenerateIdValidation = true,
                            ResourceName = "ResourceGroup",
                            Resource = "ResourceGroups",
                            ResourceIdName = "ResourceGroupId",
                        }
                    }
                }
            });
        }

        // NOTE: fake placeholder data for now to build against
        return new JsonResult(new TerraformV1Response
        {
            DataSources = new Dictionary<string, DataSourceResponse>(),
            Resources = new Dictionary<string, ResourceResponse>(),
        });
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
    }

    private class ResourceResponse
    {
        // TODO: Schema [incl. Docs], Mappings, Tests etc
        [JsonPropertyName("deleteMethod")]
        public MethodDefinition DeleteMethod { get; set; }
        
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("generate")]
        public bool Generate => DeleteMethod.Generate || GenerateSchema || GenerateIdValidation;

        [JsonPropertyName("generateSchema")]
        public bool GenerateSchema { get; set; }

        [JsonPropertyName("generateIdValidation")]
        public bool GenerateIdValidation { get; set; }

        [JsonPropertyName("resource")]
        public string Resource { get; set; }

        [JsonPropertyName("resourceIdName")]
        public string ResourceIdName { get; set; }

        [JsonPropertyName("resourceName")]
        public string ResourceName { get; set; }
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
}