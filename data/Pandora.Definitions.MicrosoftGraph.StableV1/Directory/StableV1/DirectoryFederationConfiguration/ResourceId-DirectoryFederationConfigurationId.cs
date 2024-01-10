// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Directory.StableV1.DirectoryFederationConfiguration;

internal class DirectoryFederationConfigurationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/federationConfigurations/{identityProviderBaseId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticFederationConfigurations", "federationConfigurations"),
        ResourceIDSegment.UserSpecified("identityProviderBaseId")
    };
}
