// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowLanguage;

internal class ListIdentityB2xUserFlowByIdLanguagesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new IdentityB2xUserFlowId();
    public override Type NestedItemType() => typeof(UserFlowLanguageConfigurationCollectionResponseModel);
    public override string? UriSuffix() => "/languages";
}
