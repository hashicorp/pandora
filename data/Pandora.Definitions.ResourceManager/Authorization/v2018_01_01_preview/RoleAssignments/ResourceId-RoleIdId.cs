using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2018_01_01_preview.RoleAssignments;

internal class RoleIdId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{roleId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.UserSpecified("roleId"),
    };
}
