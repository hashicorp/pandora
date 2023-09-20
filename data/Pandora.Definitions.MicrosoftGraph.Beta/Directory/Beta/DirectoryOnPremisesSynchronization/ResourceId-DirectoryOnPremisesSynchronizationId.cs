// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryOnPremisesSynchronization;

internal class DirectoryOnPremisesSynchronizationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/onPremisesSynchronization/{onPremisesDirectorySynchronizationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticOnPremisesSynchronization", "onPremisesSynchronization"),
        ResourceIDSegment.UserSpecified("onPremisesDirectorySynchronizationId")
    };
}
