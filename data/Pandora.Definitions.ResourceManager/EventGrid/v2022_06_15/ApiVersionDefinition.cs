// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-06-15";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Channels.Definition(),
        new DomainTopics.Definition(),
        new Domains.Definition(),
        new EventSubscriptions.Definition(),
        new PartnerConfigurations.Definition(),
        new PartnerNamespaces.Definition(),
        new PartnerRegistrations.Definition(),
        new PartnerTopics.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new SystemTopics.Definition(),
        new TopicTypes.Definition(),
        new Topics.Definition(),
        new VerifiedPartners.Definition(),
    };
}
