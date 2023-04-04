using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.ResourceGuardProxy;

internal class Definition : ResourceDefinition
{
    public string Name => "ResourceGuardProxy";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteOperation(),
        new GetOperation(),
        new PutOperation(),
        new UnlockDeleteOperation(),
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
