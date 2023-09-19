// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectorySharedEmailDomain;

internal class DirectorySharedEmailDomainId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/sharedEmailDomains/{sharedEmailDomainId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticSharedEmailDomains", "sharedEmailDomains"),
        ResourceIDSegment.UserSpecified("sharedEmailDomainId")
    };
}
