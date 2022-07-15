using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-11-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AuthorizationRulesDisasterRecoveryConfigs.Definition(),
        new AuthorizationRulesEventHubs.Definition(),
        new AuthorizationRulesNamespaces.Definition(),
        new CheckNameAvailabilityDisasterRecoveryConfigs.Definition(),
        new CheckNameAvailabilityNamespaces.Definition(),
        new ConsumerGroups.Definition(),
        new DisasterRecoveryConfigs.Definition(),
        new EventHubs.Definition(),
        new EventHubsClusters.Definition(),
        new EventHubsClustersAvailableClusterRegions.Definition(),
        new EventHubsClustersConfiguration.Definition(),
        new EventHubsClustersNamespace.Definition(),
        new Namespaces.Definition(),
        new NamespacesPrivateEndpointConnections.Definition(),
        new NamespacesPrivateLinkResources.Definition(),
        new NetworkRuleSets.Definition(),
        new SchemaRegistry.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
