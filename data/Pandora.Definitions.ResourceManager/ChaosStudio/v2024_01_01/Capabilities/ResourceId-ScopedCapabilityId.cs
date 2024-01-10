using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2024_01_01.Capabilities;

internal class ScopedCapabilityId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.Chaos/targets/{targetName}/capabilities/{capabilityName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftChaos", "Microsoft.Chaos"),
        ResourceIDSegment.Static("staticTargets", "targets"),
        ResourceIDSegment.UserSpecified("targetName"),
        ResourceIDSegment.Static("staticCapabilities", "capabilities"),
        ResourceIDSegment.UserSpecified("capabilityName"),
    };
}
