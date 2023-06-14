using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GraphServices.v2023_04_13.Graphservicesprods;

internal class Definition : ResourceDefinition
{
    public string Name => "Graphservicesprods";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AccountsCreateAndUpdateOperation(),
        new AccountsDeleteOperation(),
        new AccountsGetOperation(),
        new AccountsListByResourceGroupOperation(),
        new AccountsListBySubscriptionOperation(),
        new AccountsUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreatedByTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccountResourceModel),
        typeof(AccountResourcePropertiesModel),
        typeof(AccountResourceSystemDataModel),
        typeof(TagUpdateModel),
    };
}
