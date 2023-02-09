using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.ShareSubscription;

internal class Definition : ResourceDefinition
{
    public string Name => "ShareSubscription";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelSynchronizationOperation(),
        new ConsumerSourceDataSetsListByShareSubscriptionOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByAccountOperation(),
        new ListSourceShareSynchronizationSettingsOperation(),
        new ListSynchronizationDetailsOperation(),
        new ListSynchronizationsOperation(),
        new SynchronizeOperation(),
    };
}
