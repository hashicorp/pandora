using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.Deployments;

internal class ScopeId : ResourceID
{
    public string? CommonAlias => "Scope";

    public string ID => "/{resourceId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {

    };
}
