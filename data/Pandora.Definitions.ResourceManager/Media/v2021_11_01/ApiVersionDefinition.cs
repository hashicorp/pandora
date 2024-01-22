// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-11-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AccountFilters.Definition(),
        new Accounts.Definition(),
        new AssetsAndAssetFilters.Definition(),
        new ContentKeyPolicies.Definition(),
        new Encodings.Definition(),
        new LiveEvents.Definition(),
        new LiveOutputs.Definition(),
        new StreamingEndpoints.Definition(),
        new StreamingPoliciesAndStreamingLocators.Definition(),
    };
}
