using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_08_01.DppResourceGuardProxies;

internal class Definition : ResourceDefinition
{
    public string Name => "DppResourceGuardProxies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DppResourceGuardProxyCreateOrUpdateOperation(),
        new DppResourceGuardProxyDeleteOperation(),
        new DppResourceGuardProxyGetOperation(),
        new DppResourceGuardProxyListOperation(),
        new DppResourceGuardProxyUnlockDeleteOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ResourceGuardOperationDetailModel),
        typeof(ResourceGuardProxyBaseModel),
        typeof(ResourceGuardProxyBaseResourceModel),
        typeof(UnlockDeleteRequestModel),
        typeof(UnlockDeleteResponseModel),
    };
}
