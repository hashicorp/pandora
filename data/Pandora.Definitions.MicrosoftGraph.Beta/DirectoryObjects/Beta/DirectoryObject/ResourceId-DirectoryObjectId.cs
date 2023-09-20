// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.DirectoryObjects.Beta.DirectoryObject;

internal class DirectoryObjectId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directoryObjects/{directoryObjectId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectoryObjects", "directoryObjects"),
        ResourceIDSegment.UserSpecified("directoryObjectId")
    };
}
