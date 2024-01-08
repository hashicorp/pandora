using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.BastionHosts;

internal class Definition : ResourceDefinition
{
    public string Name => "BastionHosts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DeleteBastionShareableLinkOperation(),
        new DeleteBastionShareableLinkByTokenOperation(),
        new DisconnectActiveSessionsOperation(),
        new GetOperation(),
        new GetActiveSessionsOperation(),
        new GetBastionShareableLinkOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new PutBastionShareableLinkOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BastionConnectProtocolConstant),
        typeof(BastionHostSkuNameConstant),
        typeof(IPAllocationMethodConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BastionActiveSessionModel),
        typeof(BastionHostModel),
        typeof(BastionHostIPConfigurationModel),
        typeof(BastionHostIPConfigurationPropertiesFormatModel),
        typeof(BastionHostPropertiesFormatModel),
        typeof(BastionHostPropertiesFormatNetworkAclsModel),
        typeof(BastionSessionStateModel),
        typeof(BastionShareableLinkModel),
        typeof(BastionShareableLinkListRequestModel),
        typeof(BastionShareableLinkTokenListRequestModel),
        typeof(IPRuleModel),
        typeof(ResourceModel),
        typeof(SessionIdsModel),
        typeof(SkuModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
    };
}
