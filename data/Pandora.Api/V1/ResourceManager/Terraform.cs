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
        // NOTE: fake placeholder data for now to build against
        return new JsonResult(new TerraformV1Response
        {
            DataSources = new Dictionary<string, DataSourceResponse>(),
            Resources = new Dictionary<string, ResourceResponse>
            {
                {
                    "resource_group", new ResourceResponse
                    {
                        DisplayName = "Resource Group",
                        GenerateDelete = false,
                        GenerateImport = true,
                        GenerateSchema = false,
                        GenerateIdValidation = false,
                        Resource = "ResourceGroups",
                        ResourceIdName = "ResourceGroupId",
                    }
                }
            }
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
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("generate")]
        public bool Generate => GenerateDelete || GenerateImport || GenerateSchema || GenerateIdValidation;

        [JsonPropertyName("generateDelete")]
        public bool GenerateDelete { get; set; }

        [JsonPropertyName("generateImport")]
        public bool GenerateImport { get; set; }

        [JsonPropertyName("generateSchema")]
        public bool GenerateSchema { get; set; }

        [JsonPropertyName("generateIdValidation")]
        public bool GenerateIdValidation { get; set; }

        // TODO: should this be ResourceUri?
        [JsonPropertyName("resource")]
        public string Resource { get; set; }

        [JsonPropertyName("resourceIdName")]
        public string ResourceIdName { get; set; }
    }
}