using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.ConsumerInvitation;

internal class ConsumerInvitationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.DataShare/locations/{locationName}/consumerInvitations/{invitationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDataShare", "Microsoft.DataShare"),
        ResourceIDSegment.Static("staticLocations", "locations"),
        ResourceIDSegment.UserSpecified("locationName"),
        ResourceIDSegment.Static("staticConsumerInvitations", "consumerInvitations"),
        ResourceIDSegment.UserSpecified("invitationId"),
    };
}
