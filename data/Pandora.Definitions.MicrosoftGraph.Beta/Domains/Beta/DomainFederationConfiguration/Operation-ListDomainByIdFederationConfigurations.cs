// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Domains.Beta.DomainFederationConfiguration;

internal class ListDomainByIdFederationConfigurationsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new DomainId();
    public override Type NestedItemType() => typeof(InternalDomainFederationCollectionResponseModel);
    public override string? UriSuffix() => "/federationConfiguration";
}
