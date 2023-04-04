using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_06_01_preview.Subscriptions;

internal class Definition : ResourceDefinition
{
    public string Name => "Subscriptions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByTopicOperation(),
        new RulesGetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EntityStatusConstant),
        typeof(FilterTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionModel),
        typeof(CorrelationFilterModel),
        typeof(MessageCountDetailsModel),
        typeof(RuleModel),
        typeof(RulepropertiesModel),
        typeof(SBClientAffinePropertiesModel),
        typeof(SBSubscriptionModel),
        typeof(SBSubscriptionPropertiesModel),
        typeof(SqlFilterModel),
    };
}
