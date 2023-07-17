using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.PrivateEndpointConnections;

internal class ScopedPrivateEndpointConnectionId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/privateEndpointConnections/{privateEndpointConnectionName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticPrivateEndpointConnections", "privateEndpointConnections"),
        ResourceIDSegment.UserSpecified("privateEndpointConnectionName"),
    };
}
