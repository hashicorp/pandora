using System;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ElasticSan.Terraform;

public class ElasticSanResource : TerraformResourceDefinition
{
    public string DisplayName => "Elastic San";
    public ResourceID ResourceId => new v2021_11_20_preview.ElasticSans.ElasticSanId();
    public string ResourceLabel => "elastic_san";
    public Type? SchemaModel => typeof(ElasticSanResourceSchema);
    public TerraformMappingDefinition SchemaMappings => null; // TODO: implement mappings
    public TerraformResourceTestDefinition Tests => new ElasticSanResourceTests();

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    public MethodDefinition CreateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_20_preview.ElasticSans.CreateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_20_preview.ElasticSans.DeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_20_preview.ElasticSans.GetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2021_11_20_preview.ElasticSans.UpdateOperation),
        TimeoutInMinutes = 30,
    };
}
