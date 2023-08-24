using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.SecurityPartnerProviders;

internal class Definition : ResourceDefinition
{
    public string Name => "SecurityPartnerProviders";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(SecurityPartnerProviderConnectionStatusConstant),
        typeof(SecurityProviderNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SecurityPartnerProviderModel),
        typeof(SecurityPartnerProviderPropertiesFormatModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
    };
}
