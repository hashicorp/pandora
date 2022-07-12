using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineImages;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineImages";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new EdgeZoneGetOperation(),
        new EdgeZoneListOperation(),
        new EdgeZoneListOffersOperation(),
        new EdgeZoneListPublishersOperation(),
        new EdgeZoneListSkusOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListOffersOperation(),
        new ListPublishersOperation(),
        new ListSkusOperation(),
    };
}
