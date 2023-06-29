using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2022_04_01.DenyAssignments;

internal class ScopedDenyAssignmentId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.Authorization/denyAssignments/{denyAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAuthorization", "Microsoft.Authorization"),
        ResourceIDSegment.Static("staticDenyAssignments", "denyAssignments"),
        ResourceIDSegment.UserSpecified("denyAssignmentId"),
    };
}
