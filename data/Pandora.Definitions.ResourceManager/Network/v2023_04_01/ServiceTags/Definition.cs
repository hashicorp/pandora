using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.ServiceTags;

internal class Definition : ResourceDefinition
{
    public string Name => "ServiceTags";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServiceTagInformationListOperation(),
        new ServiceTagsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ServiceTagInformationModel),
        typeof(ServiceTagInformationPropertiesFormatModel),
        typeof(ServiceTagsListResultModel),
    };
}
