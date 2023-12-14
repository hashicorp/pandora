// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Domains.Beta.DomainSharedEmailDomainInvitation;

internal class ListDomainByIdSharedEmailDomainInvitationsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new DomainId();
    public override Type NestedItemType() => typeof(SharedEmailDomainInvitationCollectionResponseModel);
    public override string? UriSuffix() => "/sharedEmailDomainInvitations";
}
