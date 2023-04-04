using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.VirtualNetworkRules;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualNetworkRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByAccountOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateOrUpdateVirtualNetworkRuleParametersModel),
        typeof(CreateOrUpdateVirtualNetworkRulePropertiesModel),
        typeof(UpdateVirtualNetworkRuleParametersModel),
        typeof(UpdateVirtualNetworkRulePropertiesModel),
        typeof(VirtualNetworkRuleModel),
        typeof(VirtualNetworkRulePropertiesModel),
    };
}
