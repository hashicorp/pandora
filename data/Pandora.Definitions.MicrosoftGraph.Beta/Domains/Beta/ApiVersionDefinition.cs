// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Domains.Beta;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "Beta";
    public bool Preview => true;
    public Source Source => Source.MicrosoftGraphMetadata;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Domain.Definition(),
        new DomainDomainNameReference.Definition(),
        new DomainFederationConfiguration.Definition(),
        new DomainServiceConfigurationRecord.Definition(),
        new DomainSharedEmailDomainInvitation.Definition(),
        new DomainVerificationDnsRecord.Definition()
    };
}
