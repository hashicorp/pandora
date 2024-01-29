// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2024-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ApplicationGroup.Definition(),
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
        new EventHubsClustersUpgrade.Definition(),
        new Namespaces.Definition(),
        new NamespacesNetworkSecurityPerimeterConfigurations.Definition(),
        new NamespacesPrivateEndpointConnections.Definition(),
        new NamespacesPrivateLinkResources.Definition(),
        new NetworkRuleSets.Definition(),
        new SchemaRegistry.Definition(),
    };
}
