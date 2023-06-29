using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2022_04_01.DenyAssignments;

internal class DenyAssignmentIdId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{denyAssignmentId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.UserSpecified("denyAssignmentId"),
    };
}
