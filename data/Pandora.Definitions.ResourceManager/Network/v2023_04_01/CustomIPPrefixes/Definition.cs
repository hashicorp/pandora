using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.CustomIPPrefixes;

internal class Definition : ResourceDefinition
{
    public string Name => "CustomIPPrefixes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CommissionedStateConstant),
        typeof(CustomIPPrefixTypeConstant),
        typeof(GeoConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CustomIPPrefixModel),
        typeof(CustomIPPrefixPropertiesFormatModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
    };
}
