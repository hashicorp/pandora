using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ResourceHealthMetadata;

internal class Definition : ResourceDefinition
{
    public string Name => "ResourceHealthMetadata";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetBySiteOperation(),
        new GetBySiteSlotOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListBySiteOperation(),
        new ListBySiteSlotOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ResourceHealthMetadataModel),
        typeof(ResourceHealthMetadataPropertiesModel),
    };
}
