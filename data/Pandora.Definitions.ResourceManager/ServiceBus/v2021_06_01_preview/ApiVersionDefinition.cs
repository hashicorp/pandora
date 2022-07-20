using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_06_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-06-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DisasterRecoveryConfigs.Definition(),
        new MigrationConfigs.Definition(),
        new Namespaces.Definition(),
        new NamespacesAuthorizationRule.Definition(),
        new NamespacesPrivateEndpointConnections.Definition(),
        new NamespacesPrivateLinkResources.Definition(),
        new Queues.Definition(),
        new QueuesAuthorizationRule.Definition(),
        new Rules.Definition(),
        new Subscriptions.Definition(),
        new Topics.Definition(),
        new TopicsAuthorizationRule.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
