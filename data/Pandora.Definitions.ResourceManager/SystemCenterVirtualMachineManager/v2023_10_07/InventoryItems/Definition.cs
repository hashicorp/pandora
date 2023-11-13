using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.InventoryItems;

internal class Definition : ResourceDefinition
{
    public string Name => "InventoryItems";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByVMMServerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(InventoryTypeConstant),
        typeof(OsTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CloudInventoryItemModel),
        typeof(InventoryItemModel),
        typeof(InventoryItemDetailsModel),
        typeof(InventoryItemPropertiesModel),
        typeof(VirtualMachineInventoryItemModel),
        typeof(VirtualMachineTemplateInventoryItemModel),
        typeof(VirtualNetworkInventoryItemModel),
    };
}
