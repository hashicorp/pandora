using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Triggers;

internal class Definition : ResourceDefinition
{
    public string Name => "Triggers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetEventSubscriptionStatusOperation(),
        new ListByFactoryOperation(),
        new QueryByFactoryOperation(),
        new StartOperation(),
        new StopOperation(),
        new SubscribeToEventsOperation(),
        new UnsubscribeFromEventsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EventSubscriptionStatusConstant),
        typeof(TriggerRuntimeStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(TriggerModel),
        typeof(TriggerFilterParametersModel),
        typeof(TriggerQueryResponseModel),
        typeof(TriggerResourceModel),
        typeof(TriggerSubscriptionOperationStatusModel),
    };
}
