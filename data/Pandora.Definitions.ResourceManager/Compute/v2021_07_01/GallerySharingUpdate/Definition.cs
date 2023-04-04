using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GallerySharingUpdate;

internal class Definition : ResourceDefinition
{
    public string Name => "GallerySharingUpdate";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GallerySharingProfileUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SharingProfileGroupTypesConstant),
        typeof(SharingUpdateOperationTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SharingProfileGroupModel),
        typeof(SharingUpdateModel),
    };
}
