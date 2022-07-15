using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ClusterExtensions.Definition(),
        new ExtensionOperationStatus.Definition(),
        new Extensions.Definition(),
        new Flux.Definition(),
        new FluxConfiguration.Definition(),
        new FluxConfigurationOperationStatus.Definition(),
        new OperationsInACluster.Definition(),
        new SourceControlConfiguration.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
