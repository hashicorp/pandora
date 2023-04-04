using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_02_01.ListPrivateLinkResources;

internal class Definition : ResourceDefinition
{
    public string Name => "ListPrivateLinkResources";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PrivateLinkResourcesListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PrivateLinkResourceModel),
        typeof(PrivateLinkResourcePropertiesModel),
    };
}
