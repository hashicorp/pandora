using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.Share;

internal class Definition : ResourceDefinition
{
    public string Name => "Share";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByAccountOperation(),
        new ListSynchronizationDetailsOperation(),
        new ListSynchronizationsOperation(),
        new ProviderShareSubscriptionsGetByShareOperation(),
        new ProviderShareSubscriptionsListByShareOperation(),
        new ProviderShareSubscriptionsReinstateOperation(),
        new ProviderShareSubscriptionsRevokeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataSetTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(ShareKindConstant),
        typeof(ShareSubscriptionStatusConstant),
        typeof(StatusConstant),
        typeof(SynchronizationModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataShareErrorInfoModel),
        typeof(OperationResponseModel),
        typeof(ProviderShareSubscriptionModel),
        typeof(ProviderShareSubscriptionPropertiesModel),
        typeof(ShareModel),
        typeof(SharePropertiesModel),
        typeof(ShareSynchronizationModel),
        typeof(SynchronizationDetailsModel),
    };
}
