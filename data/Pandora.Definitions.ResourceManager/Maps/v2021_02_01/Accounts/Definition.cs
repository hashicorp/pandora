using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts;

internal class Definition : ResourceDefinition
{
    public string Name => "Accounts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new RegenerateKeysOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(KeyTypeConstant),
        typeof(KindConstant),
        typeof(NameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(MapsAccountModel),
        typeof(MapsAccountKeysModel),
        typeof(MapsAccountPropertiesModel),
        typeof(MapsAccountUpdateParametersModel),
        typeof(MapsKeySpecificationModel),
        typeof(SkuModel),
    };
}
