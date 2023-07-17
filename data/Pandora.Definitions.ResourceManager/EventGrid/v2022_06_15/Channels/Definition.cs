using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.Channels;

internal class Definition : ResourceDefinition
{
    public string Name => "Channels";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetFullUrlOperation(),
        new ListByPartnerNamespaceOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ChannelProvisioningStateConstant),
        typeof(ChannelTypeConstant),
        typeof(EventDefinitionKindConstant),
        typeof(ReadinessStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ChannelModel),
        typeof(ChannelPropertiesModel),
        typeof(ChannelUpdateParametersModel),
        typeof(ChannelUpdateParametersPropertiesModel),
        typeof(EventSubscriptionFullUrlModel),
        typeof(EventTypeInfoModel),
        typeof(InlineEventPropertiesModel),
        typeof(PartnerTopicInfoModel),
        typeof(PartnerUpdateTopicInfoModel),
    };
}
