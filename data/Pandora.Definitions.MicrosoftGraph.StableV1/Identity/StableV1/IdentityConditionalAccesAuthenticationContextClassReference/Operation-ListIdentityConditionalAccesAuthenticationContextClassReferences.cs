// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityConditionalAccesAuthenticationContextClassReference;

internal class ListIdentityConditionalAccesAuthenticationContextClassReferencesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => null;
    public override Type NestedItemType() => typeof(AuthenticationContextClassReferenceCollectionResponseModel);
    public override string? UriSuffix() => "/identity/conditionalAccess/authenticationContextClassReferences";
}
