using System;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.Terraform;

public class ChaosStudioExperimentResource : TerraformResourceDefinition
{
    public string DisplayName => "Chaos Studio Experiment";
    public ResourceID ResourceId => new v2022_07_01_preview.Experiments.ExperimentId();
    public string ResourceLabel => "chaos_studio_experiment";
    public string ResourceDescription => "TODO: regen";
    public string ResourceCategory => "TODO: regen";
    public Type? SchemaModel => typeof(ChaosStudioExperimentResourceSchema);
    public TerraformMappingDefinition SchemaMappings => new ChaosStudioExperimentResourceMappings();
    public TerraformResourceTestDefinition Tests => new ChaosStudioExperimentResourceTests();

    public bool GenerateIDValidationFunction => true;
    public bool GenerateModel => true;
    public bool GenerateSchema => true;

    public MethodDefinition CreateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_07_01_preview.Experiments.CreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition DeleteMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_07_01_preview.Experiments.DeleteOperation),
        TimeoutInMinutes = 30,
    };
    public MethodDefinition ReadMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_07_01_preview.Experiments.GetOperation),
        TimeoutInMinutes = 5,
    };
    public MethodDefinition? UpdateMethod => new MethodDefinition
    {
        Generate = true,
        Method = typeof(v2022_07_01_preview.Experiments.CreateOrUpdateOperation),
        TimeoutInMinutes = 30,
    };
}
