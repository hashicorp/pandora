using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_05_01.ManagementLocks;

internal class ScopedLockId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.Authorization/locks/{lockName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAuthorization", "Microsoft.Authorization"),
        ResourceIDSegment.Static("staticLocks", "locks"),
        ResourceIDSegment.UserSpecified("lockName"),
    };
}
