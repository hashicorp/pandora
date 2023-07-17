using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.PartnerTopics;

internal class Definition : ResourceDefinition
{
    public string Name => "PartnerTopics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ActivateOperation(),
        new CreateOrUpdateOperation(),
        new DeactivateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EventDefinitionKindConstant),
        typeof(PartnerTopicActivationStateConstant),
        typeof(PartnerTopicProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EventTypeInfoModel),
        typeof(InlineEventPropertiesModel),
        typeof(PartnerTopicModel),
        typeof(PartnerTopicPropertiesModel),
        typeof(PartnerTopicUpdateParametersModel),
    };
}
