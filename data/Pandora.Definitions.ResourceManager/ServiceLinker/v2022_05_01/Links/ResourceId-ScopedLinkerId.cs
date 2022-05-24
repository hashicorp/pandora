using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.Links;

internal class ScopedLinkerId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{resourceUri}/providers/Microsoft.ServiceLinker/linkers/{linkerName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("resourceUri"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftServiceLinker", "Microsoft.ServiceLinker"),
        ResourceIDSegment.Static("staticLinkers", "linkers"),
        ResourceIDSegment.UserSpecified("linkerName"),
    };
}
